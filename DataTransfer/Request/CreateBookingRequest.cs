namespace DataTransfer.Request;

public class CreateBookingRequest
{
    public int BadmintonCourtId { get; set; }
    public List<CreateBookingSlotRequest> CreateBookingSlotRequests { get; set; }
    public int PriceTotal { get; set; }
}