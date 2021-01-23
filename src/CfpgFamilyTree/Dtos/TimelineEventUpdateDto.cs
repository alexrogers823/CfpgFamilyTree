using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Dtos
{
    public class TimelineEventUpdateDto
    {
        public int? Day { get; set; }

        public int? Month { get; set; }

        [Required]
        [MaxLength(4)]
        public int Year { get; set; }

        [Required]
        public string Event { get; set; }
    }
}