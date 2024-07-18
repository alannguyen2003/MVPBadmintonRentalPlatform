namespace DataTransfer.Response;

public class BookingByDateOfOwner
{
    public string BadmintonCourtName { get; set; }
    public DateTime Date { get; set; }
    public int TotalBooked { get; set; }
    public List<BookingDetailOwner> BookingDetailOwners { get; set; }
}