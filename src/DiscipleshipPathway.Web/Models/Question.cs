namespace DiscipleshipPathway.Web.Models
{
    public class Question
    {
        public const int Totally_Agree = 5;

        public Question(string text, int weight, int section, string sectionLabel, int order)
        {
            ArgumentNullException.ThrowIfNull(text);

            Text = text;
            Weight = weight;
            Section = section;
            SectionLabel = sectionLabel;
            Order = order;
            Id = Guid.NewGuid().ToString();
        }

        public string Text { get; private set; }
        public int Weight { get; private set; }
        public int Section { get; private set; }
        public string SectionLabel { get; private set; }
        public int Order { get; private set; }
        public int Answer { get; private set; }
        public string Id { get; private set; }

        internal void AnswerQuestion(int answer)
        {
            Answer = Normalize(answer);
        }

        private int Normalize(int answer)
        {
            return Totally_Agree + answer * Weight * ((answer - Totally_Agree) / (2 * answer * Weight * Weight) * Math.Abs(Weight) + (answer - Totally_Agree) / (2 * answer * Weight));
        }
    }
}
