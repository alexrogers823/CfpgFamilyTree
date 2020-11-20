using System;
using System.Collections.Generic;
using System.Linq;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
    public class SqlMemberRepo : IMemberRepo
    {
        private readonly MemberContext _context;

        public SqlMemberRepo(MemberContext context)
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
  }
}