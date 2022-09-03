using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class QuestionModel :BaseEntity
    {

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Question { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Answer1 { get; set; }

        [Column(TypeName = "nvarchar(Max)")]
        public string Answer2 { get; set; }

        [Column(TypeName = "bit")]
        public bool IsImage { get; set; }
    }
}
