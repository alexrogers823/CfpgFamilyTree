using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepo _repository;
        private readonly IMapper _mapper;
        private readonly CfpgContext _dbContext;

        public MemberController(IMemberRepo repository, IMapper mapper, CfpgContext dbContext)
        {
            _repository = repository; 
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAllFamilyMembers()
        {
            var members = _repository.GetAllFamilyMembers();

            return Ok(_mapper.Map<IEnumerable<MemberReadDto>>(members));
        }

        [HttpGet("{id}", Name="GetFamilyMemberById")]
        public ActionResult <MemberReadDto> GetFamilyMemberById(int id)
        {
            var member = _repository.GetFamilyMemberById(id);
            if (member != null)
            {
                // return Ok(_mapper.Map<MemberReadDto>(member));
                var query = from mem in _dbContext.Members
                         join par in _dbContext.Members
                         on mem.PrimaryParentId equals par.Id 
                         into memberPlusParent
                         from familyLine in memberPlusParent.DefaultIfEmpty()
                         select new { 
                            Id = mem.Id,
                            FirstName = mem.FirstName,
                            MiddleName = mem.MiddleName,
                            LastName = mem.LastName,
                            PreferredName = mem.PreferredName,
                            Suffix = mem.Suffix,
                            ProfilePhotoUrl = mem.ProfilePhotoUrl, //not currently in read dto
                            BirthDay = mem.BirthDay,
                            BirthMonth = mem.BirthMonth,
                            BirthYear = mem.BirthYear,
                            Birthdate = mem.Birthdate,
                            Residence = mem.Residence,
                            Biography = mem.Biography,
                            IsAlive = mem.IsAlive,
                            DeathDay = mem.DeathDay,
                            DeathMonth = mem.DeathMonth,
                            DeathYear = mem.DeathYear,
                            DeceasedDate = mem.DeceasedDate,
                            PrimaryParentId = mem.PrimaryParentId,
                            PrimaryParentName = familyLine.PreferredName != null ? familyLine.PreferredName : familyLine.FirstName,
                            SecondaryParentId = mem.SecondaryParentId,
                            SpouseId = mem.SpouseId
                         };
                        //  where mem.Id equals id;

                return Ok(query.FirstOrDefault(m => m.Id.Equals(id)));

                // var result = _dbContext.Members.GroupJoin(
                //     _dbContext.Members,
                //     mem => mem.PrimaryParentId,
                //     par => par.Id,
                //     (member, parent ) => new { member, parent }
                // )
                // .SelectMany(
                //     x => x.parent.DefaultIfEmpty(),
                //     (fammember, famparent) => new { fammember, famparent }
                // );
                // .FirstOrDefault(m => m.member.Id.Equals(id));

                // return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult <MemberReadDto> CreateMember(MemberCreateDto memberCreateDto)
        {
            var memberModel = _mapper.Map<Member>(memberCreateDto);
            _repository.CreateMember(memberModel);
            _repository.SaveChanges();

            var memberReadDto = _mapper.Map<MemberReadDto>(memberModel);

            return CreatedAtRoute(nameof(GetFamilyMemberById), new {Id = memberReadDto.Id}, memberReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMember(int id, MemberUpdateDto memberUpdateDto)
        {
            var memberModel = _repository.GetFamilyMemberById(id);
            if (memberModel == null)
            {
                return NotFound();
            }

            _mapper.Map(memberUpdateDto, memberModel);
            _repository.UpdateMember(memberModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateMember(int id, JsonPatchDocument<MemberUpdateDto> patchDoc)
        {
            var memberModel = _repository.GetFamilyMemberById(id);

            if(memberModel == null)
            {
                return NotFound();
            }

            var memberPatch = _mapper.Map<MemberUpdateDto>(memberModel);
            patchDoc.ApplyTo(memberPatch, ModelState);
            if(!TryValidateModel(memberPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(memberPatch, memberModel);

            _repository.UpdateMember(memberModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMember(int id)
        {
            var memberModel = _repository.GetFamilyMemberById(id);

            if(memberModel == null)
            {
                return NotFound();
            }

            _repository.DeleteMember(memberModel);
            _repository.SaveChanges();

            return NoContent();

        }
    }
}