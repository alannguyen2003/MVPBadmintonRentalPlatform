namespace DataTransfer.Request;

public class CreateBookingSlotRequest
{
    public int CourtId { get; set; }
    public List<string> TimeFrames { get; set; }
    public DateTime Date { get; set; }
}