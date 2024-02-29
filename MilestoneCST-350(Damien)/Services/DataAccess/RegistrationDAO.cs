using MilestoneCST_350_Damien_.Models;
using MySql.Data.MySqlClient;

namespace MilestoneCST_350_Damien_.Services.DataAccess
{
    public class RegistrationDAO
    {
        private static string ConnectionString = @"datasource=localhost;port=3306;username=root;password=root;database=minesweeper;";

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
