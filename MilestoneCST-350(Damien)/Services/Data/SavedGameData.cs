using Microsoft.AspNetCore.Components.QuickGrid;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilestoneCST_350_Damien_.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Text.Json;

namespace MilestoneCST_350_Damien_.Services.Data
{
    public class SavedGameData
    {
        // Class Level Variables
        private static string ConnectionString = @"datasource=localhost;port=3306;username=root;password=root;database=minesweeper;";

        /// <summary>
        /// This method saves a game to the SQL Database
        /// </summary>
        /// <param name="savedGame"></param>
        /// <returns></returns>
        public bool SaveOneGame(SavedGameModel savedGame)
        {
            // Declare and initialize our flag as false
            bool isSuccessful = false;

            // Get the userId, the time the game was saved, and the board to be saved 
            int userId = savedGame.UserId;
            string timeSaved = savedGame.TimeSaved;
            var jsonGame = JsonConvert.SerializeObject(savedGame.GameBoard);


            // Query string to query db for inserting a saved game
            string sqlStatement = "INSERT INTO savedgames (UserId, TimeSaved, Game) VALUES (@userId, @timeSaved, @game)";

            // using statement to ensure objects are disposed of correctly.
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);

                command.Parameters.Add("@userId", MySqlDbType.Int32, 3).Value = userId;
                command.Parameters.Add("@timeSaved", MySqlDbType.VarChar, 40).Value = timeSaved;
                command.Parameters.Add("@game", MySqlDbType.LongText).Value = jsonGame;

                // Use try catch when opening a db just in case ther is an exception
                try
                {
                    // User the connection object
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        isSuccessful = true;
                        Console.WriteLine("RowsAffected: {0}", rowsAffected);
                    }
                    else
                    {
                        Console.WriteLine("No rows affected. Check the data or table structure.");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // Return the result
            return isSuccessful;
        }

        /// <summary>
        /// This method gets a saved game from the SQL database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GameBoardModel GetOneGame(int id)
        {
            // Declare FoundSavedBoard as a dataype GameBoardModel
            GameBoardModel FoundSavedBoard = null;

            // JSON string of the game board (empty for now)
            string jsonStringGame = "";


            // Query string to get the saved game based on the id argument
            string sqlStatement = "SELECT * FROM savedgames WHERE Id = @Id";

            // Use using so all connections get closed when done
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);

                // Fill in the placeholder for the query string 
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();

                    // Open up the reader. ExecuteReader returns object that can be iterated over to read entire results set.
                    MySqlDataReader reader = command.ExecuteReader();

                    //Then read the results of the query (Only have one result)
                    if (reader.Read())
                    {
                        jsonStringGame = (string)reader[3];
                    }

                    // Deserialize the JSON string game board back into a GameBoardModel
                    FoundSavedBoard = JsonConvert.DeserializeObject<GameBoardModel>(jsonStringGame);
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                };
            }

            // return the found saved game
            return FoundSavedBoard;
        }


        /// <summary>
        /// Delete's a game from the SQL Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteOneGame(int id)
        {
            // Declare and Initialize rowsAffected
            int rowsAffected = -1;

            // SQL Query to delete a saved game from the database
            string deleteStatement = "DELETE FROM savedgames WHERE Id = @Id";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                //Nested using statements allows for proper management of multiple resource, ensuring that eaach resource
                // is disposed of correctly.
                using (MySqlCommand command = new MySqlCommand(deleteStatement, connection))
                {
                    // Fill in the placeholder for the query string 
                    command.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        connection.Open();
                        
                        // Execute non query (Delete Query above)
                        rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine("Rows affected: " + rowsAffected);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error deleting record: " + ex.Message);
                        rowsAffected = 0;
                    }
                }
            }
            // return the amount of rows affected
            return rowsAffected;
        }

        /// <summary>
        /// This method gets all of the save games for the current user form the SQL database
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<SavedGameModel> GetAllGames(int userId)
        {
            // Declare and initialize a list of saved games
            List<SavedGameModel> listOfSavedGames = new List<SavedGameModel>();

            // Query string to query db for all of the saved games based on the userId
            string sqlStatement = "SELECT * FROM savedgames  WHERE UserId = @userid";


            // using statement to ensure objects are disposed of correctly.
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);

                command.Parameters.Add("@userid", MySqlDbType.Int32, 40).Value = userId;

                // Use try catch when opening a db just in case ther is an exception
                try
                {
                    // User the connection object
                    connection.Open();

                    //Execute the query and read the results
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // get the saved game board JSON string and deserialize back into a GameBoardModel
                        var savedGame = JsonConvert.DeserializeObject<GameBoardModel>((string)reader[3]);

                        // add the saved game to the list of saved games
                        listOfSavedGames.Add(new SavedGameModel((int)reader[0], (int)reader[1], (string)reader[2], savedGame));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // Return the the list of saved games for that user.
            return listOfSavedGames;
        }
    }
}
