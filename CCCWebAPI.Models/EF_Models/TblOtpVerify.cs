using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCCWebAPI.Models.EF_Models
{
    public class TblOtpVerify
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Otp { get; set; }
        public DateTime Createddate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool Isverify { get; set; }
        public DateTime VerifyDate { get; set; }
    }
}
