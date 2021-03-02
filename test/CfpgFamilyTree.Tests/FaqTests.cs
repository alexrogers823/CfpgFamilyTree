using System;
using CfpgFamilyTree.Models;
using Xunit;

namespace CfpgFamilyTree.Tests
{
    public class FaqTests : IDisposable
    {
        Faq testQuestion;
        public FaqTests()
        {
            testQuestion = new Faq
            {
                Question = "Who killed Jefferson Pierce's father?",
                Answer = "Tobias Whale"
            };
        }

        public void Dispose()
        {
            testQuestion = null;
        }

        [Fact]
        public void CanChangeQuestionAndAnswer()
        {
            testQuestion.Question = "Who killed Barry Allen's mother?";
            testQuestion.Answer = "Eobard Thawne";

            Assert.Equal("Who killed Barry Allen's mother?", testQuestion.Question);
            Assert.Equal("Eobard Thawne", testQuestion.Answer);
        }
    }
}