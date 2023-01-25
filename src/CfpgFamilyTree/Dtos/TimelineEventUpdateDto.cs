using System;
using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Dtos
{
    public class TimelineEventUpdateDto
    {
        public int? Day { get; set; }

        public int? Month { get; set; }

        public int Year { get; set; }

        public DateTime EventDate { get; set; }

        [Required]
        public string Event { get; set; }
    }
}