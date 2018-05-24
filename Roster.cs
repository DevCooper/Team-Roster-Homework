using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRoster
{
    public class Roster : BaseObjectCollection<Player>
    {
        /// <summary>
        /// Gets all the players currently in the Roster table in the PlayerRoster database.
        /// </summary>
        /// <returns>A roster of the player currently in the Roster table.</returns>
        public static Roster GetAll()
        {
            var roster = new Roster();
            var dataSet = new PlayerDataService().GetAll();

            roster.MapObjects(dataSet);
            return roster;
        }

        /// <summary>
        /// Checks if a given number is already taken by a player in this Roster.
        /// </summary>
        /// <param name="number">The number to be tested.</param>
        /// <returns>True if the number does not already belong to a player in the roster.</returns>
        public bool IsAvailableNumber(int number)
        {
            foreach (var Player in this)
            {
                if (number == Player.Number)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
