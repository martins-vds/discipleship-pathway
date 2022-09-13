using DiscipleshipPathway.Web.Models;

namespace DiscipleshipPathway.Web.Services.StateService
{
    public class InMemoryReadOnceStateService : IStateService
    {
        private AssessmentResults? _results;

        public void SaveAssessmentResults(AssessmentResults? results)
        {
            if (results is null)
            {
                return;
            }

            _results = results;
        }

        public AssessmentResults? GetAssessmentResults()
        {
            var temp = _results;
            _results = null;
            return temp;
        }
    }
}
