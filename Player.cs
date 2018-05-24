using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRoster
{
    public class Player : BaseObject
    {
        /// <summary>
        /// Holds the last name of the player.
        /// </summary>
        private string lastName = string.Empty;

        /// <summary>
        /// Holds the first name of the player.
        /// </summary>
        private string firstName = string.Empty;

        /// <summary>
        /// Holds the number of the player.
        /// </summary>
        private int number;

        /// <summary>
        /// The property for the lastName backing attribute. Sets null input to an empty string.
        /// </summary>
        public string LastName
        {
            get => this.lastName;
            set => this.lastName = value ?? string.Empty;
        }

        /// <summary>
        /// The property for the firstName backing attribute. Sets null input to an empty string.
        /// </summary>
        public string FirstName
        {
            get => this.firstName;
            set => this.firstName = value ?? string.Empty;
        }

        /// <summary>
        /// The property for the number backing attribute. Sets null input to an empty string.
        /// </summary>
        public int Number
        {
            get => this.number;
            set => this.number = value >= 0 ? value : 0;
        }

        /// <summary>
        /// Returns the full title for a player including their number, followed by their last and first name.
        /// </summary>
        public string FullPlayerTitle => $"{this.Number} - {this.LastName}, {this.FirstName}";

        /// <summary>
        /// Inserts this player into the Roster table.
        /// </summary>
        /// <returns>True if the player is inserted.</returns>
        public bool Insert()
        {
            var dataService = new PlayerDataService();
            return dataService.Insert(this);
            //return new PlayerDataService().Insert(this);
        }

        /// <summary>
        /// Updates this player's information in the Roster table.
        /// </summary>
        /// <param name="oldNumber">The player's current number before it is changed.</param>
        /// <returns>True if the player is updated.</returns>
        public bool Update(int oldNumber)
        {
            return new PlayerDataService().Update(this, oldNumber);
        }

        /// <summary>
        /// Deletes this player from the Roster table.
        /// </summary>
        /// <returns>True if the player is deleted.</returns>
        public bool Delete()
        {
            return new PlayerDataService().Delete(this.Number);
        }

        /// <summary>
        /// Deletes the player with a specified number from the Roster table.
        /// </summary>
        /// <param name="number">The number of the player to be deleted.</param>
        /// <returns>True if the player is deleted.</returns>
        public static bool Delete(int number)
        {
            return new PlayerDataService().Delete(number);
        }

        /// <summary>
        /// Maps the data from a Data Row.
        /// </summary>
        /// <param name="row">The Data Rows to be mapped.</param>
        /// <returns>Returns true if the data is successfully mapped.</returns>
        public override bool MapData(DataRow row)
        {
            this.Number = Convert.ToInt32(row["PlayerNumber"]);
            this.LastName = row["LastName"].ToString();
            this.FirstName = row["FirstName"].ToString();

            return base.MapData(row);
        }

        /// <summary>
        /// Creates a string representation of this Player object.
        /// </summary>
        /// <returns>This player's number followed by Last Name and First Name.</returns>
        public override string ToString() => $"{this.Number} - {this.LastName}, {this.FirstName}";

        /// <summary>
        /// Tests if a given object is equal to this Player object.
        /// </summary>
        /// <param name="obj">The object to be tested.</param>
        /// <returns>True if the objects are equal.</returns>
        public override bool Equals(object obj)
        {
            var that = obj as Player;
            if (that == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, that))
            {
                return true;
            }

            return this.Number == that.Number;
        }

        /// <summary>
        /// Generates the hash code for this player object.
        /// </summary>
        /// <returns>The hash code of this player object.</returns>
        public override int GetHashCode() => this.Number.GetHashCode();
    }
}
