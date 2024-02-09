using MilestoneCST_350_Damien_.Models;

namespace MilestoneCST_350_Damien_.Services
{
    public class SecurityService
    {
        // Create an object of the DAO Class so we can use the database lookup query
        private SecurityDAO securityDAO = new SecurityDAO();

        /// <summary>
        /// Methods that calls DAO and returns the bool result
        /// </summary>
        /// <param name="user"></param>
        /// <returns>boolean</returns>
        public bool IsValid(UserModel user)
        {
            return securityDAO.FindUserByNameAndPassword(user);
        }
    }
}
