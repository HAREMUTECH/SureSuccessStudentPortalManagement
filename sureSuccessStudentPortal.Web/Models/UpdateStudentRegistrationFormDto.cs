using System.ComponentModel.DataAnnotations;

namespace SureSuccessStudentPortal.Web
{
    public class UpdateStudentRegistrationFormDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
    }
}
