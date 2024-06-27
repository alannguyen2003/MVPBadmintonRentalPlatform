namespace DataTransfer.Response;

public class GenerateSlotResponseForOwner
{
    public int Id { get; set; }
    public string CourtCode { get; set; }
    public List<SlotWithStatusResponseForOwner> SlotWithStatusResponsesForOwner { get; set; }
}