using System;
using System.ComponentModel.DataAnnotations;

namespace CfpgFamilyTree.Models 
{
    public class User 
    {
        [Key]
        public int Id { get; set; }

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

        public DateTime CreatedOn { get; set; }

        public DateTime LastLoggedIn { get; set; }
    }
}