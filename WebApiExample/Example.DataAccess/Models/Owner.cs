using System.ComponentModel.DataAnnotations;

namespace Example.DataAccess.Models;

public class Owner
{
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string SecondName { get; set; }
    
    public DateTime CreatedTimestamp { get; set; }
}