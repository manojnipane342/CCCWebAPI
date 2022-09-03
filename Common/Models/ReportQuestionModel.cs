using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class ReportQuestionModel
    {
       

        [Key]
        public int Id { get; set; }

        public int ReportId { get; set; }

        public int QuestionId { get; set; }

        [Column(TypeName = "bit")]
        public bool IsAnswer1 { get; set; }

        [Column(TypeName = "bit")]
        public bool IsAnswer2 { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string ImageName { get; set; }

        [ForeignKey("ReportId")]
        public virtual ReportModel? Report { get; set;  }

        [ForeignKey("QuestionId")]
        public virtual QuestionModel? Question { get; set; }
    }
}
