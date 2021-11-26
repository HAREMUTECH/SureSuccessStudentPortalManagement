﻿using System;

namespace SureSuccessStudentPortal.Web
{
    public class StudentRegistrationFormDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }
}
