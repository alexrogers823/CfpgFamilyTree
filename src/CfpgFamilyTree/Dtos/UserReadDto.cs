using System;

namespace CfpgFamilyTree.Dtos
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string Email { get; set; }
        public string Birthplace { get; set; }
        public string Residence { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime LastLoggedIn { get; set; }
    }
}