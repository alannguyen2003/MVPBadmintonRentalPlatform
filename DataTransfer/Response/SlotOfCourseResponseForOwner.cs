namespace DataTransfer.Response;

public class SlotOfCourseResponseForOwner
{
    public int CourtId { get; set; }
    public string CourtName { get; set; }
    public GenerateSlotResponseForOwner GenerateSlotResponseForOwner { get; set; }
}