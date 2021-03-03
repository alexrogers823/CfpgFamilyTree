using System;
using System.Collections.Generic;
using System.Linq;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
    public class SqlMemberRepo : IMemberRepo
    {
        private readonly CfpgContext _context;

        public SqlMemberRepo(CfpgContext context)
        {
            _context = context;
        }

        public void CreateMember(Member member)
        {
            if(member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            _context.Members.Add(member);
        }

        public void DeleteMember(Member member)
        {
            if(member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            _context.Members.Remove(member);
        }

        public IEnumerable<Member> GetAllFamilyMembers()
        {
            return _context.Members.ToList();
        }

        public Member GetFamilyMemberById(int id)
        {
            return _context.Members.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMember(Member member)
        {

        }
  }
}