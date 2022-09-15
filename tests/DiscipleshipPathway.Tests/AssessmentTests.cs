using DiscipleshipPathway.Web.Models;
using FluentAssertions;
using System.Collections.Generic;

namespace DiscipleshipPathway.Tests
{
    public class AssessmentTests
    {
        [Fact]
        public void Test1()
        {
            Assessment assessment = new Assessment();

            Question question = new Question(text: "A question", weight: 1, section: 1, sectionLabel: "Section", order: 1);
            Question anotherQuestion = new Question(text: "Another question", weight: -1, section: 2, sectionLabel: "Another section", order: 1);

            assessment.AddQuestion(question);
            assessment.AddQuestion(anotherQuestion);

            assessment.AnswerQuestion(question.Id, 1);
            assessment.AnswerQuestion(anotherQuestion.Id, 1);

            AssessmentResults results = assessment.CalculateResults();

            results.Should().BeEquivalentTo(new AssessmentResults()
            {
                AverageBySection = new List<SectionAverage>()
                {
                    new SectionAverage()
                    {
                        Section = "Section",
                        Average = 1
                    },
                    new SectionAverage()
                    {
                        Section = "Another section",
                        Average = 5
                    }
                }
            });
        }
    }
}
