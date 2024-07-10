namespace DataTransfer.Response;

public class BookingDetailResponse
{
    public int BookingId { get; set; }
    public DateTime Date { get; set; }
    public List<SlotResponse> Slots { get; set; }
}