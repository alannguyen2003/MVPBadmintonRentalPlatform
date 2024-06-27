using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("Transactions")]
public class Transaction : BaseEntity
{
    [ForeignKey("AccountId")]
    public int AccountId { get; set; }
    public virtual Account Account { get; set; }
    
    [ForeignKey("TransactionTypeId")]
    public int TransactionTypeId { get; set; }
    public virtual TransactionType TransactionType { get; set; }
    
    public int Amount { get; set; }
    
    [ForeignKey("TransactionStatusId")]
    public int TransactionStatusId { get; set; }
    public virtual TransactionStatus TransactionStatus { get; set; }
    public DateTime Timestamp { get; set; }
}