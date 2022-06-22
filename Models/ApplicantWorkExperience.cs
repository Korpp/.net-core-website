using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace MyWebPage.Models
{
    public class ApplicantWorkExperience
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Employer { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public List<ApplicantWorkExperience> GetDetails()
        {
            List<ApplicantWorkExperience> Experience = new List<ApplicantWorkExperience>();
            return Experience;
        }
    }
}
