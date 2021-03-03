using System.Collections.Generic;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
    public interface IFaqRepo
    {
        bool SaveChanges();
        IEnumerable<Faq> GetAllQuestions();
        Faq GetQuestionById(int id);
        void CreateQuestion(Faq question);
        void UpdateQuestion(Faq question);
        void DeleteQuestion(Faq question);
    }
}