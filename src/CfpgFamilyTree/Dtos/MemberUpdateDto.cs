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

        public int? BirthDay { get; set; }

        public int? BirthMonth { get; set; }

        [Required]
        public int? BirthYear { get; set; }

        public int? DeathDay { get; set; }

        public int? DeathMonth { get; set; }

        public int? DeathYear { get; set; }

        public string Birthplace { get; set; }

        public string Residence { get; set; }

        [Required]
        public bool IsAlive { get; set; }

        public bool HasSpouse { get; set; }

        public int? PrimaryParentId { get; set; }

        public int? SecondaryParentId { get; set; }

        public bool IsActiveUser { get; set; }

        public int? SpouseId { get; set; }

        public int? UserId { get; set; }
    }
}