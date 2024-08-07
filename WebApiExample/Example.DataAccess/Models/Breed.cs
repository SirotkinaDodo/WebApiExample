using System.ComponentModel.DataAnnotations;

namespace Example.DataAccess.Models;

public class Breed
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(15)]
    public string Name { get; set; }
    
    [Required]
    public DateTime CreatedTimestamp { get; set; }
}