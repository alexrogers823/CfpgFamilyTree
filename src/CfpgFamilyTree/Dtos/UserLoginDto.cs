using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Dtos
{
    public class UserLoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string InputPassword { get; set; }
    }
}