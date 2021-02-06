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

        public string Birthplace { get; set; }

        public string Residence { get; set; }

        public string BioParagraph1 { get; set; }

        public string BioParagraph2 { get; set; }

        public string BioParagraph3 { get; set; }

        public string BioParagraph4 { get; set; }

        public string BioParagraph5 { get; set; }

        public string BioParagraph6 { get; set; }
        
        public string BioParagraph7 { get; set; }

        public int DeathDay { get; set; }

        public int DeathMonth { get; set; }

        public int DeathYear { get; set; }

        public int PrimaryParentId { get; set; }

        public int SecondaryParentId { get; set; }

        public int SpouseId { get; set; }
    }
}