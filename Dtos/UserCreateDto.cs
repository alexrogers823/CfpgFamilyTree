using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}