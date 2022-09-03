using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class BaseEntity
    {
        public bool? IsActive { get; set; }
        
        public bool? IsDelete { get; set; }
        
        [Column(TypeName = "DateTime")]
        public DateTime? CreatedDate { get; set; }
        
        
        public int? CreatedBy { get; set; }
        
        [Column(TypeName = "DateTime")]
        public DateTime? ModifyDate { get; set; }

       
        public int? ModifyBy { get; set; }


       

    }
}
