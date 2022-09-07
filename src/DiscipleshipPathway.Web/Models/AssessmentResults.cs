namespace DiscipleshipPathway.Web.Models
{
    public class AssessmentResults
    {
        public IList<SectionScore> AverageBySection { get; set; }

        public AssessmentResults()
        {
            AverageBySection = new List<SectionScore>();
        }
    }
}
