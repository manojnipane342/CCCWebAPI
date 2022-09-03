using System.ComponentModel.DataAnnotations;

namespace CCCWebAPI.Models.EF_Models
{
    public partial class TblPlumber
    {
        [Key]
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MiddleInital { get; set; }
        public string BusinessName { get; set; }
        public string BusinessTelephone { get; set; }
        public string BusinessFax { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string LicenceNumber { get; set; }
        //public string EmployerName { get; set; }
    }
}
