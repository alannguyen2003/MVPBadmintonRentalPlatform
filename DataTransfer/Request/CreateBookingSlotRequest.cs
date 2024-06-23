using DataTransfer.Response;

namespace DataTransfer.Request;

public class CreateBookingSlotRequest
{
    public int CourtId { get; set; }
    public List<SlotWithStatusResponse> TimeFrames { get; set; }
    public DateTime Date { get; set; }
}