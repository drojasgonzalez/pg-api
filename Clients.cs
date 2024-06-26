
using System.ComponentModel.DataAnnotations;

public class Clients
{
    [Key]
    public int Id { get; set; }

    [MaxLength(255)] 
    public string Name { get; set; }

    [MaxLength(255)] 
    public string Lastname { get; set; }

    [MaxLength(255)] 
    public string Email { get; set; }

    [MaxLength(255)]
    public string Phone { get; set; }

    [MaxLength(255)] 
    public string Country { get; set; }
}
