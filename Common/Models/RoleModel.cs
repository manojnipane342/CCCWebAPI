using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class RoleModel :BaseEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Column(TypeName = "nvarchar(20)")]
        public string RoleName { get; set; }
    }
}
