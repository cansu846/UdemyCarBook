namespace UdemyCarBook.WebUI.Models
{
    public class RentCarRequestViewModel
    {
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public DateTime? PickUpDate { get; set; }
        public DateTime? DropOffDate { get; set; }
        public string PickUpTime { get; set; }
        public string SelectedLocation { get; set; } // dropdown
    }
}
