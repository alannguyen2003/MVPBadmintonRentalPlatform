namespace DataTransfer.Response;

public class SlotWithStatusResponseForOwner
{
    public string TimeFrame { get; set; }
    public bool IsBooked { get; set; }
    public string UserBooked { get; set; }
    public string PhoneNumber { get; set; }
}