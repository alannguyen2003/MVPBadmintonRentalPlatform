namespace DataTransfer.Request;

public class OwnerRegisterRequest
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    
    public string CourtName { get; set; }
    public int NumberOfCourt { get; set; }
    public int HourStart { get; set; }
    public int MinuteStart { get; set; }
    public int HourEnd { get; set; }
    public int MinuteEnd { get; set; }
    public float PricePerHour { get; set; }
    public float PriceAtWeekend { get; set; }
    public string Address { get; set; }
}