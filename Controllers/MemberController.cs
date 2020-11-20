using System.Collections.Generic;
using AutoMapper;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepo _repository;
        private readonly IMapper _mapper;

        public MemberController(IMemberRepo repository, IMapper mapper)
        {
            _repository = repository; 
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Member>> GetAllFamilyMembers()
        {
            var members = _repository.GetAllFamilyMembers();

            return Ok(_mapper.Map<IEnumerable<MemberReadDto>>(members));
        }

        [HttpGet("{id}", Name="GetFamilyMemberById")]
        public ActionResult <Member> GetFamilyMemberById(int id)
        {
            var member = _repository.GetFamilyMemberById(id);

            return Ok(_mapper.Map<MemberReadDto>(member));
        }

        [HttpPost]
        public ActionResult <MemberCreateDto> CreateMember(MemberCreateDto memberCreateDto)
        {
            var memberModel = _mapper.Map<Member>(memberCreateDto);
            _repository.CreateMember(memberModel);
            _repository.SaveChanges();

            var memberReadDto = _mapper.Map<MemberReadDto>(memberModel);

            return CreatedAtRoute(nameof(GetFamilyMemberById), new {Id = memberReadDto.Id}, memberReadDto);
        }
    }
}