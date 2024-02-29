using MilestoneCST_350_Damien_.Models;
using MilestoneCST_350_Damien_.Services.DataAccess;

namespace MilestoneCST_350_Damien_.Services.Business
{
    public class RegistrationService
    {
        // call the registrationdao class
        RegistrationDAO registrationDAO = new RegistrationDAO();

        /// <summary>
        /// envokes the register user method
        /// </summary>
        /// <param name="user"></param>
        /// <returns> returns true if user was able to successfully register </returns>
        public bool isValid(UserModel user)
        {
            return registrationDAO.RegisterUser(user);
        }
    }
}