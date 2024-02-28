using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MilestoneCST_350_Damien_.Models
{
    public class UserModel
    {
        // Class Properties
        public int Id { get; set; }

		[Required]
		[DisplayName("First Name")]
		public string FirstName { get; set; }


		[Required]
		[DisplayName("Last Name")]
		public string LastName { get; set; }


		[Required]
		[DisplayName("Sex")]
		public string Sex { get; set; }


		[Required]
		[DisplayName("Age")]
		public int Age { get; set; }


		[Required]
		[DisplayName("State")]
		public string State { get; set; }


		[Required]
		[DisplayName("Email Address")]
		public string Email { get; set; }


		[Required]
		[DisplayName("Username")]
		[StringLength(20, MinimumLength = 5)]
		public string UserName { get; set; }


		[Required]
		[DisplayName("Password")]
		[StringLength(20, MinimumLength = 5)]
		public string Password { get; set; }
	}
}
