using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("Services")]
public class ServiceCourt : BaseEntity
{
    public string ServiceName { get; set; }
    public int BadmintonCourtId { get; set; }
    public virtual BadmintonCourt BadmintonCourt { get; set; }
}