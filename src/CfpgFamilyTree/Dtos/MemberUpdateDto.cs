using System;
using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Dtos 
{
    public class MemberUpdateDto 
    {

        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string Suffix { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime? DeceasedDate { get; set; }
        public string Birthplace { get; set; }
        public string Residence { get; set; }
        public string Biography { get; set; }
        [Required]
        public bool IsAlive { get; set; }
        public bool HasSpouse { get; set; }
        public bool IsInlaw { get; set; }
        public string PrimaryParent { get; set; }
        public int? PrimaryParentId { get; set; }
        public string SecondaryParent { get; set; }
        public int? SecondaryParentId { get; set; }
        public bool IsActiveUser { get; set; }
        public string Spouse { get; set; }
        public int? SpouseId { get; set; }
        public int? UserId { get; set; }
    }
}