using DiscipleshipPathway.Web.Models;

namespace DiscipleshipPathway.Web.Services
{
    public interface IAssessmentService
    {
        Task<Assessment> GetAssessment(CancellationToken cancellationToken = default);
    }
}
