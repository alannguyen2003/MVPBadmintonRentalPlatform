namespace DataTransfer.Response;

public class AccountResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Balance { get; set; }
    public int RoleId { get; set; }
}