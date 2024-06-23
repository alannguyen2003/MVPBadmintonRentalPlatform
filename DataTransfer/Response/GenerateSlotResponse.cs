namespace DataTransfer.Response;

public class GenerateSlotResponse
{
    public int Id { get; set; }
    public string CourtCode { get; set; }
    public List<SlotWithStatusResponse> SlotWithStatusResponses { get; set; }
    public string Status { get; set; }
}