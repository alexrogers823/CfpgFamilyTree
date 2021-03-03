using System;
using System.Collections.Generic;
using System.Linq;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
    public class SqlFaqRepo : IFaqRepo
    {
        private readonly CfpgContext _context;

        public SqlFaqRepo(CfpgContext context)
        {
            _context = context;
        }

        public void CreateQuestion(Faq question)
        {
            if (question == null)
            {
                throw new ArgumentNullException(nameof(question));
            }

            _context.Questions.Add(question);
        }

        public void DeleteQuestion(Faq question)
        {
            if(question == null)
            {
                throw new ArgumentNullException(nameof(question));
            }

            _context.Questions.Remove(question);
        }

        public IEnumerable<Faq> GetAllQuestions()
        {
            return _context.Questions.ToList();
        }

        public Faq GetQuestionById(int id)
        {
            return _context.Questions.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateQuestion(Faq question)
        {
            
        }
    }
}