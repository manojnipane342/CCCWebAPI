using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class CertificationModel :BaseEntity
    {
        [Key]
        public int Id { get; set; }


        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }


    }
}
