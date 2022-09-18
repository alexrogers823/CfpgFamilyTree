using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace CfpgFamilyTree.Models 
{
    public class Member 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PreferredName { get; set; }

        public string Suffix { get; set; }

        public string ProfilePhotoUrl { get; set; }

        // TODO: Write Validation method to account for February 
        [Range(1, 31, ErrorMessage="Value for {0} must be between {1} and {2}")]
        public int BirthDay { get; set; }

        [Range(1, 12, ErrorMessage="Value for {0} must be between {1} and {2}")]
        public int BirthMonth { get; set; }

        [Required]
        public int BirthYear { get; set; }

        [Range(1, 31, ErrorMessage="Value for {0} must be between {1} and {2}")]
        public int? DeathDay { get; set; }

        [Range(1, 12, ErrorMessage="Value for {0} must be between {1} and {2}")]
        public int? DeathMonth { get; set; }

        public int? DeathYear { get; set; }

        public string Birthplace { get; set; }

        public string Residence { get; set; }

        public string BioParagraph1 { get; set; }

        public string BioParagraph2 { get; set; }

        public string BioParagraph3 { get; set; }

        public string BioParagraph4 { get; set; }

        public string BioParagraph5 { get; set; }

        public string BioParagraph6 { get; set; }
        
        public string BioParagraph7 { get; set; }

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