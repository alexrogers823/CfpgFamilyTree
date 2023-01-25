using System;

namespace CfpgFamilyTree.Dtos
{
    public class TimelineEventReadDto
    {
        public int Id { get; set; }

        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public DateTime EventDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedByUserId { get; set; }

        public string Event { get; set; }
    }
}