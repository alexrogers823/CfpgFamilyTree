using System.Collections.Generic;
using CfpgFamilyTree.Models;
using CfpgFamilyTree.Data;

namespace CfpgFamilyTree.Data
{
    public interface IMemberRepo
    {
        bool SaveChanges();
        IEnumerable<Member> GetAllFamilyMembers();
        Member GetFamilyMemberById(int id);

        void CreateMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(Member member);
    }
}