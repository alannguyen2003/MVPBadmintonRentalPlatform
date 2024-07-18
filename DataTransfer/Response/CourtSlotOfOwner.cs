namespace DataTransfer.Response;

public class CourtSlotOfOwner
{
    public int CourtNumber { get; set; }
    public List<SlotOfOwnerResponse> SlotResponses { get; set; }
}