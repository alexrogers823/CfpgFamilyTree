using CfpgFamilyTree.DataStructures;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
    public interface IDynamicTree
    {
        TreeNode GetFamilyTree(Member rootMember);
        TreeNode CreateTreeNode(Member member);
    }
}