
namespace MyWebPage.Models
{
    public class _Applicant
    {
        // public int Id { get; set; }
        public IEnumerable<ApplicantDetails> appDetails { get; set; }
        public IEnumerable<ApplicantSkills> appSkills { get; set; }
        public IEnumerable<ApplicantWorkExperience> appWork { get; set; }
    }
}


