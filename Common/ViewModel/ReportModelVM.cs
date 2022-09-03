
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class ReportModelVM
    {
    
        public int Id { get; set; }

        public int UserId { get; set; }

        public string HouseNo { get; set; }

        public string StreetName { get; set; }

        public string OwnerName { get; set; }

        public int BoroughId { get; set; }

        public string Block { get; set; }

        public string LOT { get; set; }

        public string BIN { get; set; }

        public string CommunityBoardNo { get; set; }

        public string NumberOfStories { get; set; }

        public string NumberOfMeters { get; set; }

        public string ActiveMeters { get; set; }

        public string AdditionalComments { get; set; }

        public bool IsAdditionalCommentsImage { get; set; }

        public string? AdditionalCommentsImageName { get; set; }

        public DateTime? DateOfInitialInspection { get; set; }

        public bool IsFinalize { get; set; }

        public virtual UserModelVM? User { get; set; }

        public virtual BoroughModelVM? Borough { get; set; }
    }
}
