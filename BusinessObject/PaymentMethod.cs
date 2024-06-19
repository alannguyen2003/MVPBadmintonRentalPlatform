using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("PaymentMethods")]
public class PaymentMethod : BaseEntity
{
    public string PaymentName { get; set; }
    [ForeignKey("BankId")]
    public int BankId { get; set; }
    public virtual Bank Bank { get; set; }
    
    public ICollection<Booking> Bookings { get; set; }
    
}