using System.ComponentModel.DataAnnotations.Schema;

namespace Example.DataAccess.Models;

[Table("DogToOwner")]
public class OwnerDog
{
    public Guid DogId { get; set; }
    
    public Guid OwnerId { get; set; }
}