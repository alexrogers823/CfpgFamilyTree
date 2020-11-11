using System.Collections.Generic;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
    public interface IMemberRepo
    {
        IEnumerable<Member> GetAllFamilyMembers();
        Member GetFamilyMemberById(int id);
    }
}