using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MilestoneCST_350_Damien_.Models
{
    public class DifficultyModel
    {
        [Required]
        [DisplayName("Difficulty(Range: 0.01 - 0.10)")]
        [Range(0.01, 0.10, ErrorMessage = "Difficulty value must be from 0.01 to 0.10")]
        public double Difficulty { get; set; }


        [Required]
        [DisplayName("Size Of Game Board(Range: 5 - 16)")]
        [Range(5, 16, ErrorMessage = "Board size must be from 5 to 16")]
        public int SizeOfBoard { get; set; }


    }
}
