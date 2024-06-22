namespace DataTransfer.Response;

public class BadmintonCourtSlotReponse
{
    public int CourtId { get; set; }
    public string CourtName { get; set; }
    public List<GenerateSlotResponse> GenerateSlotResponses { get; set; }
}