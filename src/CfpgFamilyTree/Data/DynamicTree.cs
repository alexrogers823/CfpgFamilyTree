using System.Linq;
using CfpgFamilyTree.DataStructures;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
    public class DynamicTree : IDynamicTree
    {
        private readonly CfpgContext _context;

        public DynamicTree(CfpgContext context)
        {
            _context = context;
        }

        public TreeNode GetFamilyTree(Member rootMember)
        {
            return CreateTreeNode(rootMember);
        }

        public TreeNode CreateTreeNode(Member member)
        {
            var children = _context.Members.Where(c => c.PrimaryParentId == member.Id);
            // var children = _context.Members.FirstOrDefault(p => p.FirstName == "Josh"); //Defaults to null
            // TreeNode[] childrenSet = children.Select(child => CreateTreeNode(child)).ToArray();

            return new TreeNode 
            {
                Id = member.Id,
                PreferredName = member.FirstName,
                LastName = member.LastName,
                IsInlaw = member.IsInlaw,
                SpouseId = member.SpouseId,
                Children = (children.Count() < 1) ? null : children.ToList().Select(child => CreateTreeNode(child)).ToArray()
            };
        }
    }
}