using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}