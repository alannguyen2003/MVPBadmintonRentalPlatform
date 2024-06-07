using System.ComponentModel.DataAnnotations;

namespace BusinessObject;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}

