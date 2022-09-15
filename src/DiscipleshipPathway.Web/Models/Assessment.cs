using System.Collections.Immutable;

namespace DiscipleshipPathway.Web.Models
{
    public class Assessment
    {
        private readonly IList<Question> _questions;
        public IReadOnlyList<Question> Questions
        {
            get
            {
                return _questions.OrderBy(x => x.Order).ToImmutableList();
            }
        }

        public Assessment()
        {
            _questions = new List<Question>();
        }

        public Assessment(IEnumerable<Question> questions)
        {
            _questions = questions.ToList();
        }

        public void AddQuestion(Question question)
        {
            _questions.Add(question);
        }

        public void AnswerQuestion(string id, int answer)
        {
            var question = _questions.FirstOrDefault(x => x.Id == id);

            if (question == null)
            {
                return;
            }

            question.AnswerQuestion(answer);
        }

        public AssessmentResults CalculateResults()
        {
            var results = new AssessmentResults();

            var questionsBySection = _questions.GroupBy(q => q.SectionLabel);

            foreach (var groupOfQuestions in questionsBySection)
            {
                results.AverageBySection.Add(new SectionAverage()
                {
                    Section = groupOfQuestions.Key,
                    Average = groupOfQuestions.Sum(q => q.Answer) / (double)groupOfQuestions.Count()
                });
            }

            return results;
        }
    }
}
