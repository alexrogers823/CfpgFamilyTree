using System.Collections.Generic;
using AutoMapper;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Controllers
{
    [Route("api/artifacts")]
    [ApiController]
    public class ArtifactController : ControllerBase
    {
        private readonly IArtifactRepo _repository;
        private readonly IMapper _mapper;

        public ArtifactController(IArtifactRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Artifact>> GetAllArtifacts()
        {
            var artifacts = _repository.GetAllArtifacts();

            return Ok(_mapper.Map<IEnumerable<ArtifactReadDto>>(artifacts));
        }

        [HttpGet("{id}", Name="GetArtifactById")]
        public ActionResult <Artifact> GetArtifactById(int id)
        {
            var artifact = _repository.GetArtifactById(id);
            if (artifact != null)
            {
                return Ok(_mapper.Map<ArtifactReadDto>(artifact));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult <ArtifactCreateDto> CreateArtifact(ArtifactCreateDto artifactCreateDto)
        {
            var artifactModel = _mapper.Map<Artifact>(artifactCreateDto);
            _repository.CreateArtifact(artifactModel);
            _repository.SaveChanges();

            var artifactReadDto = _mapper.Map<ArtifactCreateDto>(artifactModel);

            return CreatedAtRoute(nameof(GetArtifactById), new {Id = artifactReadDto.Id}, artifactReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateArtifact(int id, ArtifactUpdateDto artifactUpdateDto)
        {
            var artifactModel = _repository.GetArtifactById(id);
            if (artifactModel == null)
            {
                return NotFound();
            }

            _mapper.Map(artifactUpdateDto, artifactModel);
            _repository.UpdateArtifact(artifactModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateArtifact(int id, JsonPatchDocument<ArtifactUpdateDto> patchDoc)
        {
            var artifactModel = _repository.GetArtifactById(id);

            if (artifactModel == null)
            {
                return NotFound();
            }

            var artifactPatch = _mapper.Map<ArtifactUpdateDto>(artifactModel);
            patchDoc.ApplyTo(artifactPatch, ModelState);
            if(!TryValidateModel(artifactPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(artifactPatch, artifactModel);

            _repository.UpdateArtifact(artifactModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteArtifact(int id)
        {
            var artifactModel = _repository.GetArtifactById(id);

            if (artifactModel == null)
            {
                return NotFound();
            }

            _repository.DeleteArtifact(artifactModel);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}