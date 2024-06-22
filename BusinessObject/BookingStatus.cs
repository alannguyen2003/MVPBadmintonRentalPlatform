using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("BookingStatus")]
public class BookingStatus : BaseEntity
{
    public string Status { get; set; }
}