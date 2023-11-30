using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.DataStructures;
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
        private readonly IDynamicTree _tree;

        public MemberController(IMemberRepo repository, IMapper mapper, CfpgContext dbContext, IDynamicTree tree)
        {
            _repository = repository; 
            _mapper = mapper;
            _dbContext = dbContext;
            _tree = tree;
        }

        [HttpGet("tree", Name="GetFamilyTree")]
        public ActionResult GetFamilyTree()
        {
            Member treeRoot = _dbContext.Members.SingleOrDefault(member => member.PrimaryParentId == null && member.IsInlaw == false);
            TreeNode tree = _tree.GetFamilyTree(treeRoot);
            
            return Ok(tree);
        }

        [HttpGet]
        public ActionResult <IEnumerable<MemberReadDto>> GetAllFamilyMembers()
        {
            var members = _repository.GetAllFamilyMembers();

            return Ok(_mapper.Map<IEnumerable<MemberReadDto>>(members));
        }

        [HttpGet("{id}", Name="GetFamilyMemberById")]
        public ActionResult GetFamilyMemberById(int id)
        {
            var member = _repository.GetFamilyMemberById(id);
            if (member != null)
            {
                return Ok(_mapper.Map<MemberReadDto>(member));
                // var query = from mem in _dbContext.Members
                //          join par in _dbContext.Members on mem.PrimaryParentId equals par.Id
                //          into primaryParentTable
                //          from primaryParent in primaryParentTable.DefaultIfEmpty()
                //          join sec in _dbContext.Members on mem.SecondaryParentId equals sec.Id
                //          into secondaryParentTable 
                //          from secondaryParent in secondaryParentTable.DefaultIfEmpty() 
                //          join spo in _dbContext.Members on mem.SpouseId equals spo.Id
                //          into spouseTable 
                //          from spouse in spouseTable.DefaultIfEmpty()   
                //          select new { 
                //             Id = mem.Id,
                //             FirstName = mem.FirstName,
                //             MiddleName = mem.MiddleName,
                //             LastName = mem.LastName,
                //             PreferredName = mem.PreferredName,
                //             Suffix = mem.Suffix,
                //             ProfilePhotoUrl = mem.ProfilePhotoUrl, //not currently in read dto
                //             Birthdate = mem.Birthdate,
                //             Birthplace = mem.Birthplace,
                //             Residence = mem.Residence,
                //             Biography = mem.Biography,
                //             IsAlive = mem.IsAlive,
                //             IsInlaw = mem.IsInlaw,
                //             DeceasedDate = mem.DeceasedDate,
                //             PrimaryParentId = mem.PrimaryParentId,
                //             PrimaryParentName = primaryParent.PreferredName != null ? primaryParent.PreferredName : primaryParent.FirstName,
                //             SecondaryParentId = mem.SecondaryParentId,
                //             SecondaryParentName = secondaryParent.PreferredName != null ? secondaryParent.PreferredName : secondaryParent.FirstName,
                //             SpouseId = mem.SpouseId,
                //             SpouseName = spouse.PreferredName != null ? spouse.PreferredName : spouse.FirstName
                //          };

                // return Ok(query.FirstOrDefault(m => m.Id.Equals(id)));

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