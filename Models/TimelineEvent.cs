using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Models
{
    public class TimelineEvent
    {
        [Key]
        public int Id { get; set; }

        public int? Day { get; set; }

        public int? Month { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Event { get; set; }
    }
}