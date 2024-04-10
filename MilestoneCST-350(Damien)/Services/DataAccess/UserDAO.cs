using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.Data;
using MySql.Data.MySqlClient;

namespace MilestoneCST_350_Damien_.Services.DataAccess
{
	public class UserDAO
	{
		// class level
		private UserData userData = new UserData();

		/// <summary>
		/// Finds user by username and password
		/// Returns the user's id
		/// </summary>
		/// <param name="user"></param>
		/// <returns>bool</returns>
		public int FindUserByNameAndPassword(UserModel user)
		{

			return userData.FindUserByNameAndPassword(user);
		}

		/// <summary>
		/// Registers a new user
		/// Returns true if registration was successful
		/// </summary>
		/// <param name="user"></param>
		/// <returns>bool</returns>
		public bool RegisterUser(UserModel user)
		{
			return userData.RegisterUser(user);
		}
	}
}

