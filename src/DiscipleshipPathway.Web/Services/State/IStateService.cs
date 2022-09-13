using DiscipleshipPathway.Web.Models;

namespace DiscipleshipPathway.Web.Services.StateService
{
    public interface IStateService
    {
        void SaveAssessmentResults(AssessmentResults? results);
        AssessmentResults? GetAssessmentResults();
    }
}