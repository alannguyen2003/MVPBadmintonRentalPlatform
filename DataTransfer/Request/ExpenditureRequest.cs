namespace DataTransfer.Request;

public class ExpenditureRequest
{
    public int TransactionTypeId { get; set; }
    public int Amount { get; set; }
    public DateTime DateTime { get; set; }
}