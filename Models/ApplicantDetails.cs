using System.ComponentModel.DataAnnotations;

namespace MyWebPage.Models
{
    public class ApplicantDetails
    {
        public int Id { get; set; }
        public string profileImage { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Age { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Address { get; set; }

        //[RegularExpression(@"^[0-9]*$")]
        [Required]
        public int PostalCode { get; set; }

        
        [Required]
        public string City { get; set; }       
        public int Phonenumber { get; set; }
        public string Email { get; set; }
        public string LinkedIn { get; set; }
        public string GitHub { get; set; }
        public List<ApplicantDetails> GetDetails()
        {
            List<ApplicantDetails> Details = new List<ApplicantDetails>();
            return Details;
        }
    }
}
