using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MilestoneCST_350_Damien_.Models
{
    public class DifficultyModel
    {
        // Difficulty Model Properties
		public int UserId { get; set; }

		[Required]
        [DisplayName("Difficulty(Range: 0.01 - 0.10)")]
        [Range(0.01, 0.10, ErrorMessage = "Difficulty value must be from 0.01 to 0.10")]
        public double Difficulty { get; set; }


        [Required]
        [DisplayName("Size Of Game Board(Range: 5 - 10)")]
        [Range(5, 10, ErrorMessage = "Board size must be from 5 to 10")]
        public int SizeOfBoard { get; set; }


    }
}
