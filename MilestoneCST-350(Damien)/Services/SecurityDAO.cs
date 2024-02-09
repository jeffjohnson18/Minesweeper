using MilestoneCST_350_Damien_.Models;
using MySql.Data.MySqlClient;

namespace MilestoneCST_350_Damien_.Services
{
    public class SecurityDAO
    {
        private string ConnectionString = @"datasource=localhost;port=3306;username=root;password=root;database=minesweeper;";


        /// <summary>
        /// Create a SQL query in the method to search for a record by username
        /// and password
        /// Returns true if match is found
        /// </summary>
        /// <param name="user"></param>
        /// <returns>bool</returns>
        public bool FindUserByNameAndPassword(UserModel user)
        {
            //Assume nothing is found
            // Declare and initialize our flag as false
            bool isSuccessful = false;

            // Query string to query db for password and username
            string sqlStatement = "SELECT * FROM users WHERE UserName = @userName AND Password = @password";

            // using statement to ensure objects are disposed of correctly.
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                // Instantiate SqlCommand and pass the constructor the query and connection.
                //SqlCommand allows us to query and send commands to the database
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);

                // Define the value of the two placeholders in the query
                // Using the object "command" 
                command.Parameters.Add("@userName", MySqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", MySqlDbType.VarChar, 40).Value = user.Password;

                // Use try catch when opening a db just in case ther is an exception
                try
                {
                    // User the connection object
                    connection.Open();

                    //Execute the query and read the results
                    // command object has already had the query statement sent to the constructor

                    MySqlDataReader reader = command.ExecuteReader();

                    // Let's see if there are any rows found
                    if (reader.HasRows)
                    {
                        // update the flag so we can return that our user was found
                        isSuccessful = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // Retunr the result
            return isSuccessful;
        }
    }
}
