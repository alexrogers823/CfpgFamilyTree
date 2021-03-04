using System.Collections.Generic;
using AutoMapper;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Controllers
{
    public class FaqController : ControllerBase
    {
        private readonly IFaqRepo _repository;
        private readonly IMapper _mapper;

        public FaqController(IFaqRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<FaqReadDto>> GetAllQuestions()
        {
            var questions = _repository.GetAllQuestions();

            return Ok(_mapper.Map<IEnumerable<FaqReadDto>>(questions));
        }

        [HttpGet("{id}", Name="GetQuestionById")]
        public ActionResult <FaqReadDto> GetQuestionById(int id)
        {
            var question = _repository.GetQuestionById(id);
            if (question != null)
            {
                return Ok(_mapper.Map<FaqReadDto>(question));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult <FaqReadDto> CreateQuestion(FaqCreateDto faqCreateDto)
        {
            var questionModel = _mapper.Map<Faq>(faqCreateDto);
            _repository.CreateQuestion(questionModel);
            _repository.SaveChanges();

            var faqReadDto = _mapper.Map<FaqReadDto>(questionModel);

            return CreatedAtRoute(nameof(GetQuestionById), new {Id = faqReadDto.Id}, faqReadDto);
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateQuestion(int id, JsonPatchDocument<FaqUpdateDto> patchDoc)
        {
            var questionModel = _repository.GetQuestionById(id);

            if (questionModel == null)
            {
                return NotFound();
            }

            var questionPatch = _mapper.Map<FaqUpdateDto>(questionModel);
            patchDoc.ApplyTo(questionPatch, ModelState);

            if(!TryValidateModel(questionPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(questionPatch, questionModel);

            _repository.UpdateQuestion(questionModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteQuestion(int id)
        {
            var questionModel = _repository.GetQuestionById(id);

            if (questionModel == null)
            {
                return NotFound();
            }

            _repository.DeleteQuestion(questionModel);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}