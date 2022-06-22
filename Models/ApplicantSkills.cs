namespace MyWebPage.Models
{
    public class ApplicantSkills
    {
        public int Id { get; set; }
        public string Skill { get; set; }
        public string Description { get; set; }

        public List<ApplicantSkills> GetDetails()
        {
            List<ApplicantSkills> Skills = new List<ApplicantSkills>();
            return Skills;
        }
    }
}
