namespace DataTransfer.Response;

public class GenerateSlotResponse
{
    public int Id { get; set; }
    public string CourtCode { get; set; }
    public List<string> TimeFrame { get; set; }
    public string Status { get; set; }
}