namespace DiscipleshipPathway.Web.Models
{
    public class AssessmentResults
    {
        public IList<SectionAverage> AverageBySection { get; set; }

        public AssessmentResults()
        {
            AverageBySection = new List<SectionAverage>();
        }
    }
}
