using System;

namespace PatientInfo
{
    internal class Patient
    {
        public string Title { get; set; }
        public string IdNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string BloodGroup { get; set; }
        public string Genotype { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string EmergencyNumber { get; set; }
        public string HomeAddress { get; set; }
        public string Remarks { get; set; }
    }
}
