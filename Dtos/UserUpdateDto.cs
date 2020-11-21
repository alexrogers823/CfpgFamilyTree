using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Dtos
{
    public class UserUpdateDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}