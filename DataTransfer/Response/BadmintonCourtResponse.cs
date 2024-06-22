namespace DataTransfer.Response;

public class BadmintonCourtResponse
{
    public int Id { get; set; }
    public string ProfileImage { get; set; }
    public string CourtName { get; set; }
    public int NumberOfCourt { get; set; }
    public string AvailableTime { get; set; }
    public float PricePerHour { get; set; }
    public float PriceAtWeekend { get; set; }
    public float PriceAtHoliday { get; set; }
    public string Address { get; set; }
    public string Owner { get; set; }
    public string PhoneNumber { get; set; }
    public List<string> ServiceCourts { get; set; }
}