using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("TransactionStatus")]
public class TransactionStatus : BaseEntity
{
    public string Status { get; set; }
}