using DiscipleshipPathway.Web.Models;

namespace DiscipleshipPathway.Web.Services.AssessmentService
{
    public interface IAssessmentService
    {
        Task<Assessment> GetAssessment(CancellationToken cancellationToken = default);
    }
}
