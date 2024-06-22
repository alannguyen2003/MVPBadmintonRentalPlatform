namespace DataTransfer.Response;

public class SlotOfCourtResponse
{
    public int CourtId { get; set; }
    public string CourtName { get; set; }
    public GenerateSlotResponse GenerateSlotResponse { get; set; }
}