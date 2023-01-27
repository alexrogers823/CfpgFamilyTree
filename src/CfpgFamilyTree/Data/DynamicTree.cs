using System.Linq;
using CfpgFamilyTree.DataStructures;

namespace CfpgFamilyTree.Data
{
    public class DynamicTree : IDynamicTree
    {
        private readonly CfpgContext _context;

        public DynamicTree(CfpgContext context)
        {
            _context = context;
        }

        public TreeNode GetFamilyTree()
        {
            var sample = _context.Members.FirstOrDefault(p => p.Id == 3);

            return new TreeNode {
                Id = sample.Id,
                PreferredName = sample.FirstName,
                LastName = sample.LastName,
                IsInlaw = sample.IsInlaw,
                SpouseId = sample.SpouseId,
                Children = null
            };
        }
    }

}