using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Models 
{
    public class Member 
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PreferredName { get; set; }

        public string Suffix { get; set; }

        public string ProfilePhotoUrl { get; set; }

        [MaxLength(2)]
        public int BirthDay { get; set; }

        [MaxLength(2)]
        public int BirthMonth { get; set; }

        [MaxLength(2)]
        public int BirthYear { get; set; }

        [MaxLength(2)]
        public int DeathDay { get; set; }

        [MaxLength(2)]
        public int DeathMonth { get; set; }

        [MaxLength(4)]
        public int DeathYear { get; set; }

        [Required]
        public bool IsAlive { get; set; }

        public bool HasSpouse { get; set; }

        public string PrimaryParent { get; set; }

        public string SecondaryParent { get; set; }

        public bool IsActiveUser { get; set; }

        public string Spouse { get; set; }

        public int UserId { get; set; }
    }
}