using System.ComponentModel.DataAnnotations;
namespace CCCWebAPI.Models.EF_Models
{
    public partial class TblIndividualInfo
    {
        [Key]
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string MiddleIntial { get; set; }
        public string BusinessName { get; set; }
        public string BusinessTelephone { get; set; }
        public string BusinessTax { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string MobileTelephone { get; set; }
        public string Email { get; set; }
        public string EmployerName { get; set; }
    }
}
