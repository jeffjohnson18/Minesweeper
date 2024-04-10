using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.DataAccess;

namespace MilestoneCST_350_Damien_.Services.Business
{
    public class SecurityService
    {
        // Create an object of the DAO Class so we can use the database lookup query
        private UserDAO userDAO = new UserDAO();

        /// <summary>
        /// Check's if the user is valid based on the username and password.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>boolean</returns>
        public int IsValid(UserModel user)
        {
            return userDAO.FindUserByNameAndPassword(user);
        }


		/// <summary>
		/// Envokes the register user method
		/// </summary>
		/// <param name="user"></param>
		/// <returns> returns true if user was able to successfully register </returns>
		public bool RegisterUser(UserModel user)
		{
			return userDAO.RegisterUser(user);
		}
	}
}
