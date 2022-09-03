using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class ReportQuestionModelVM
    {

        public int Id { get; set; }

        public int ReportId { get; set; }

        public int QuestionId { get; set; }

        public bool IsAnswer1 { get; set; }

        public bool IsAnswer2 { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public virtual ReportModelVM? Report { get; set; }

        public virtual QuestionModelVM? Question { get; set; }
    }
}

