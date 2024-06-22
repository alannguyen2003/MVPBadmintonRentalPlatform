using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("TransactionTypes")]
public class TransactionType : BaseEntity
{
    public string TypeOfTransaction { get; set; }
}