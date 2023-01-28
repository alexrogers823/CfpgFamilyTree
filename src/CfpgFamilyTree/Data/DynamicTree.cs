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
            var children = _context.Members.Where(c => c.PrimaryParentId == member.Id).OrderBy(m => m.Birthdate);

            return new TreeNode 
            {
                Id = member.Id,
                PreferredName = (member.PreferredName != null) ? member.PreferredName : member.FirstName,
                LastName = member.LastName,
                IsInlaw = member.IsInlaw,
                SpouseId = member.SpouseId,
                Children = (children.Count() == 0) ? null : children.ToList().Select(child => CreateTreeNode(child)).ToArray()
            };
        }
    }
}