using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

[Table("Courts")]
public class Court : BaseEntity
{
    public string CourtCode { get; set; }
    public int BadmintonCourtId { get; set; }
    public virtual BadmintonCourt BadmintonCourt { get; set; }
}