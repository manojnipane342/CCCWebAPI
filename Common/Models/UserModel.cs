using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class UserModel : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MiddleInitial { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string BusinessName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string BusinessTelephone { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string BusinessFax { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string State { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ZipCode { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MobileTelephone { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string EmployerName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LicenseNumber { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string Password { get; set; }

        public int RoleId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? PasswordSalt { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string? DeviceTokenId { get; set; }




        [ForeignKey("RoleId")]
        public virtual RoleModel? Roles { get; set; }
    }
}
