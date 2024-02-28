using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.DataAccess;

namespace MilestoneCST_350_Damien_.Services.Business
{
    public class SecurityService
    {
        // Create an object of the DAO Class so we can use the database lookup query
        private LoginDAO loginDAO = new LoginDAO();

        /// <summary>
        /// Methods that calls DAO and returns the bool result
        /// </summary>
        /// <param name="user"></param>
        /// <returns>boolean</returns>
        public bool IsValid(UserModel user)
        {
            return loginDAO.FindUserByNameAndPassword(user);
        }
    }
}
