namespace CfpgFamilyTree.DataStructures
{
    public class TreeNode 
    {
        public int Id { get; set; }
        public string PreferredName { get; set; }
        public string LastName { get; set; }
        public bool IsInlaw { get; set; }
        public int? SpouseId { get; set; }
        public TreeNode[] Children { get; set; }
    }
}