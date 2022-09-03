using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class ReportModel :BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; } 

        [Column(TypeName = "nvarchar(20)")]
        public string HouseNo { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string StreetName { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string OwnerName { get; set; }

        public int BoroughId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Block { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string LOT { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string BIN { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string CommunityBoardNo { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string NumberOfStories { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NumberOfMeters { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ActiveMeters { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string AdditionalComments { get; set; }

        [Column(TypeName = "bit")]
        public bool IsAdditionalCommentsImage { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? AdditionalCommentsImageName { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? DateOfInitialInspection { get; set; }

        public bool IsFinalize { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel? User { get; set; }

        [ForeignKey("BoroughId")]
        public virtual BoroughModel? Borough { get; set; }

    }
}
