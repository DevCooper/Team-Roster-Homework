using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRoster
{
    public class PlayerDataService
    {
        /// <summary>
        /// Holds the connection information to connect to the Microsoft Access Database with the PlayerRoster
        /// database.
        /// </summary>
        private string ConnectionString { get; } = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayerRoster.accdb";

        /// <summary>
        /// Holds the statement for the insert query from the PlayerRoster database.
        /// </summary>
        private string InsertPlayerQuery { get; } = "INSERT INTO Roster (PlayerNumber, LastName, FirstName) VALUES(?, ?, ?)";

        /// <summary>
        /// Holds the statement for the delete query from the PlayerRoster database.
        /// </summary>
        private string DeletePlayerQuery { get; } = "DELETE FROM Roster WHERE PlayerNumber = ?";

        /// <summary>
        /// Holds the statement for the update query from the PlayerRoster database.
        /// </summary>
        private string UpdatePlayerQuery { get; } =
            "UPDATE Roster SET PlayerNumber = ?, LastName = ?, FirstName = ? WHERE PlayerNumber = ?";

        /// <summary>
        /// Holds the statement for the query to select all players from the PlayerRoster database.
        /// </summary>
        private string SelectAllQuery { get; } = "SELECT PlayerNumber, LastName, FirstName FROM Roster";

        /// <summary>
        /// Gets all players currently contained in the Roster table of the PlayerRoster database.
        /// </summary>
        /// <returns>A dataset of all players in the database.</returns>
        public DataSet GetAll()
        {
            var data = new DataSet();

            try
            {
                using (var connection = new OleDbConnection(this.ConnectionString))
                using (var command = new OleDbCommand(this.SelectAllQuery, connection))
                using (var adapter = new OleDbDataAdapter(command))
                {
                    connection.Open();
                    adapter.Fill(data);
                    return data;
                }
            }
            catch (OleDbException oLEDbEx)
            {
                Console.Error.WriteLine(oLEDbEx.Message);
                return data;
            }
        }

        /// <summary>
        /// Executes a non query on the PlayerRoster database.
        /// </summary>
        /// <param name="query">The statement that will be executed.</param>
        /// <param name="parameters">The parameters that will be used in the statement.</param>
        /// <returns>True if the number of rows affected is equal to one.</returns>
        private bool ExecuteNonQuery(string query, params string[] parameters)
        {
            try
            {
                using (var connection = new OleDbConnection(this.ConnectionString))
                using (var command = new OleDbCommand(query, connection))
                {
                    connection.Open();
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue("?", param);
                        }
                    } //else, no parameters DoNothing();

                    return command.ExecuteNonQuery() == 1;

                }
            }
            catch (OleDbException oLEDbEx)
            {
                Console.Error.WriteLine(oLEDbEx.Message);
                return false;
            }
        }

        /// <summary>
        /// Inserts a given player into the RosterTable.
        /// </summary>
        /// <param name="player">The player object to be inserted into the table.</param>
        /// <returns>True if the player is successfully inserted.</returns>
        public bool Insert(Player player)
        {
            return this.ExecuteNonQuery(this.InsertPlayerQuery,
                player.Number.ToString("G"),
                player.LastName,
                player.FirstName);
        }

        /// <summary>
        /// Updates a player currently in the Roster table.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="oldNumber"></param>
        /// <returns></returns>
        public bool Update(Player player, int oldNumber)
        {
            return this.ExecuteNonQuery(this.UpdatePlayerQuery,
                player.Number.ToString(),
                player.LastName,
                player.FirstName,
                oldNumber.ToString("G"));
        }

        /// <summary>
        /// Deletes a specified player from the Roster table.
        /// </summary>
        /// <param name="number">The number of the player to be deleted.</param>
        /// <returns>True if the player is deleted.</returns>
        public bool Delete(int number)
        {
            return this.ExecuteNonQuery(this.DeletePlayerQuery, number.ToString("G"));
        }


    }
}
