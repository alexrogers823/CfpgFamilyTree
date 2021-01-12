namespace CfpgFamilyTree.Dtos
{
    public class MemberReadDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PreferredName { get; set; }

        public string Suffix { get; set; }

        public int BirthDay { get; set; }

        public int BirthMonth { get; set; }

        public int BirthYear { get; set; }

        public int DeathDay { get; set; }

        public int DeathMonth { get; set; }

        public int DeathYear { get; set; }

        public int PrimaryParentId { get; set; }

        public int SecondaryParentId { get; set; }

        public int SpouseId { get; set; }
    }
}