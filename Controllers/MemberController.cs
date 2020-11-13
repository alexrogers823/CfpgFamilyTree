using System.Collections.Generic;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Controllers
{
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepo _repository;

        [HttpGet]
        public ActionResult <IEnumerable<Member>> GetAllFamilyMembers()
        {
            var members = _repository.GetAllFamilyMembers();

            return Ok(members);
        }

        [HttpGet("{id}")]
        public ActionResult <Member> GetFamilyMemberById(int id)
        {
            var member = _repository.GetFamilyMemberById(id);

            return Ok(member);
        }
    }
}