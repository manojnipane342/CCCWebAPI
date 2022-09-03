using System.ComponentModel.DataAnnotations;
namespace CCCWebAPI.Models.EF_Models
{
    public partial class TblInformationloc
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int House_No { get; set; }
        public string Street_name { get; set; }
        public string Owner_name { get; set; }
        public string Borough { get; set; }
        public string Block { get; set; }
        public string LOT { get; set; }
        public string BIN { get; set; }
        public string Community_Board { get; set; }
        public string No_stories { get; set; }
        public string No_meters { get; set; }
        public string Active_meters { get; set; }
        public string AdditionalComments { get; set; }
        public string IsAdditionalCommentsImage { get; set; }
        public string AdditionalCommentsImageName { get; set; }
        public string DateOfInitialInspection { get; set; }
        public string IsFinalize { get; set; }
    }
}
