using System.ComponentModel.DataAnnotations;

namespace Example.DataAccess.Models;

public class Dog
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }

    [Required]
    public DateTime CreatedTimestamp { get; set; }

    public int Age { get; set; }
    
    [Required]
    public Guid BreedId { get; set; }
}