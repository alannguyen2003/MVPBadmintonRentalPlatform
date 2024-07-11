namespace DataTransfer.Response;

public class BookingUserResponse
{
    public int Id { get; set; }
    public int Price { get; set; }
    public string BadmintonCourtName { get; set; }
    public int NumberOfCourt { get; set; }
    public string BadmintonCourtLocation { get; set; }
    public string UserName { get; set; }
    public string Status { get; set; }
    public DateTime DateTime { get; set; }
}