using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.DataAccess;

namespace MilestoneCST_350_Damien_.Services.Business
{
    public class SecurityService
    {
        // Create an object of the DAO Class so we can use the database lookup query
        private UserDAO userDAO = new UserDAO();

        /// <summary>
        /// Methods that calls DAO and returns the bool result
        /// </summary>
        /// <param name="user"></param>
        /// <returns>boolean</returns>
        public bool IsValid(UserModel user)
        {
            return userDAO.FindUserByNameAndPassword(user);
        }


		/// <summary>
		/// envokes the register user method
		/// </summary>
		/// <param name="user"></param>
		/// <returns> returns true if user was able to successfully register </returns>
		public bool RegisterUser(UserModel user)
		{
			return userDAO.RegisterUser(user);
		}
	}
}
