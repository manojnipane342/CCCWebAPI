using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class UserModelVM : BaseEntityVM
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleInitial { get; set; }

        public string BusinessName { get; set; }

        public string BusinessTelephone { get; set; }

        public string BusinessFax { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string MobileTelephone { get; set; }

        public string Email { get; set; }

        public string EmployerName { get; set; }

        public string LicenseNumber { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public string? PasswordSalt { get; set; }

        public string? DeviceTokenId { get; set; }

        public string? Token { get; set; }


        public virtual RoleModelVM? Roles { get; set; }
    }
}
