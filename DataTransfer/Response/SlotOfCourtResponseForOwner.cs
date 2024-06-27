namespace DataTransfer.Response;

public class SlotOfCourtResponseForOwner
{
    public int CourtId { get; set; }
    public string CourtName { get; set; }
    public GenerateSlotResponseForOwner GenerateSlotResponseForOwner { get; set; }
}