using MilestoneCST_350_Damien_.Models;
using MySql.Data.MySqlClient;

namespace MilestoneCST_350_Damien_.Services.Data
{
	public class UserData
	{
		// Class level
		private static string ConnectionString = @"datasource=localhost;port=3306;username=root;password=root;database=minesweeper;";


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

		/// <summary>
		/// Create a SQL query in the method to add a user to the SQL database.
		/// When added to SQL database the user is successfully registered.
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public bool RegisterUser(UserModel user)
		{
			// bool to store if post was successful
			bool success = false;


			string sqlStatement = "INSERT INTO users (id, firstname, lastname, sex, age, state, email, username, password) " +
					  "VALUES (@ID, @FIRSTNAME, @LASTNAME, @SEX, @AGE, @STATE, @EMAILADDRESS, @USERNAME, @PASSWORD);";

			using (MySqlConnection connection = new MySqlConnection(ConnectionString))
			{
				MySqlCommand command = new MySqlCommand(sqlStatement, connection);

				// define the values of the two placeholders in the sqlStatement string
				command.Parameters.Add("@ID", MySqlDbType.VarChar, 50).Value = user.Id;
				command.Parameters.Add("@FIRSTNAME", MySqlDbType.VarChar, 50).Value = user.FirstName;

				command.Parameters.Add("@LASTNAME", MySqlDbType.VarChar, 50).Value = user.LastName;

				command.Parameters.Add("@SEX", MySqlDbType.VarChar, 50).Value = user.Sex;

				command.Parameters.Add("@AGE", MySqlDbType.Int32, 50).Value = user.Age;

				command.Parameters.Add("@STATE", MySqlDbType.VarChar, 50).Value = user.State;

				command.Parameters.Add("@EMAILADDRESS", MySqlDbType.VarChar, 50).Value = user.Email;

				command.Parameters.Add("@USERNAME", MySqlDbType.VarChar, 50).Value = user.UserName;

				command.Parameters.Add("@PASSWORD", MySqlDbType.VarChar, 50).Value = user.Password;

				try
				{
					connection.Open();
					int rowsAffected = command.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						success = true;
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
					Console.WriteLine(ex.StackTrace);
				}
			}

			return success;
		}
	}
}

