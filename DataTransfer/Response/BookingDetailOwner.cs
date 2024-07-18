namespace DataTransfer.Response;

public class BookingDetailOwner
{
    public string CustomerName { get; set; }
    public DateTime Date { get; set; }
    public int Total { get; set; }
    public string PaymentMethod { get; set; }
    public List<CourtSlotOfOwner> CourtSlotOfOwners { get; set; }
}