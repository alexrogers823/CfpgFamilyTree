using System;
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
        [MaxLength(4)]
        public int Year { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedByUserId { get; set; }

        [Required]
        public string Event { get; set; }
    }
}