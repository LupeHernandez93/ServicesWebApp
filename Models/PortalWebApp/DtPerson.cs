namespace ServicesWebApp.Models.PortalWebApp
{
    public class DtPerson
    {
        public int IdPerson { get; set; }
        //public string TypeAccountName { get; set; }
        //public string? CompanyRFC { get; set; }
        //public string? CompanyName { get; set; }
        //public string? CompanyNickname { get; set; }
        public string? DepartmentName { get; set; }       
        public string? PositionName { get; set; }
        public string Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? EmployeeNumber { get; set; }
        public string? PersonalMail { get; set; }
        public string? Curp { get; set; }
        public string? Nss { get; set; }
        public string? BloodType { get; set; }
        public DateTime? Antiquity { get; set; }
        public DateTime? StartDateJob { get; set; }
        public DateTime? EndDateDateJob { get; set; }
        public string? PersonalPhone { get; set; }
        public string? EmergencyNumber { get; set; }
        public string? Allergies { get; set; }
        public bool Status { get; set; }
        public string? Nationality { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? CivilStatus { get; set; }
        public DateTime? CreatedDate { get; set; }

        public List<DtApplication> Applications = new List<DtApplication>() { };
    }
}
