using DiscipleshipPathway.Web.Models;
using CsvHelper;
using System.Globalization;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace DiscipleshipPathway.Web.Services
{
    public class AssessmentService : IAssessmentService
    {
        private readonly HttpClient _httpClient;

        public AssessmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Assessment> GetAssessment(CancellationToken cancellationToken = default)
        {
            using var csvStream = await _httpClient.GetStreamAsync("data/questions.csv");

            using var reader = new StreamReader(csvStream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            
            var questions = csv.GetRecords<Question>();

            return new Assessment(questions);
        }
    }
}
