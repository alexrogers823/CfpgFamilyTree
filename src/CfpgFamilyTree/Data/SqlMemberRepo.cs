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
            return _context.Members.OrderBy(m => m.LastName).ToList();

            // IEnumerable<Member> familyMembers = _context.Members.ToList();
            // IEnumerable<Member> parents = _context.Members.ToList();

            // var result = (IEnumerable<Member>)familyMembers.GroupJoin(
            //     parents,
            //     m => m.PrimaryParentId,
            //     p => p.Id,
            //     (m, p) => new { Member = m, Parent = p }
            // )
            // .SelectMany(
            //     xy => xy.Parent.DefaultIfEmpty(),
            //     (x, y) => new { Member = x.Member, Parent = y }
            // )
            // .ToList();

            // Console.WriteLine(result);

            // var query = from mem in _context.Members
            //              join par in _context.Members
            //              on mem.PrimaryParentId equals par.Id 
            //              into memberPlusParent
            //              from familyLine in memberPlusParent.DefaultIfEmpty()
            //              select new { mem, familyLine };
                         
            // List<MemberPlusParent> result = new List<MemberPlusParent>();

            // foreach (var item in query)
            // {
            //     result.Add(Name = item.mem.FirstName, ParentName = item.familyLine.FirstName);
            // }

            // return result;
        }

        public Member GetFamilyMemberById(int id)
        {
            return _context.Members.FirstOrDefault(p => p.Id.Equals(id));
            // var familyMembers = _context.Members.ToList();
            // var parents = _context.Members.ToList();

            // var result = familyMembers.GroupJoin(
            //     parents,
            //     m => m.PrimaryParentId,
            //     p => p.Id,
            //     (m, p) => new { m, p }
            // )
            // .SelectMany(
            //     x => x.p.DefaultIfEmpty(),
            //     (member, parent) => new { member, parent }
            // )
            // .ToList();
            // .FirstOrDefault(m => m.Id.Equals(id));
            // Console.WriteLine(result);

            // return result[0];
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