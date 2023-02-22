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
            var spouse = _context.Members.FirstOrDefault(m => m.SpouseId == member.Id);

            return new TreeNode 
            {
                Id = member.Id,
                PreferredName = (member.PreferredName != null) ? member.PreferredName : member.FirstName,
                LastName = member.LastName,
                IsInlaw = member.IsInlaw,
                Spouse = spouse != null ? new TreeNode { Id = spouse.Id, PreferredName = (spouse.PreferredName != null) ? spouse.PreferredName : spouse.FirstName, LastName = spouse.LastName, IsInlaw = true} : null,
                Children = (children.Count() == 0) ? null : children.ToList().Select(child => CreateTreeNode(child)).ToArray()
            };
        }
    }
}