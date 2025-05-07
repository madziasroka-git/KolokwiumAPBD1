using System.ComponentModel.DataAnnotations;

namespace KOLOS1.DTOs;

public class ReturnVisitTPO
{
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public ClientTPO Client { get; set; }
    [Required]
    public MechanicTPO Mechanic { get; set; }
    [Required]
    public List<ServiceTPO> Services { get; set; }
}

public class ClientTPO
{
    [Required]
    public string FirstName { get; set; } = String.Empty;
    [Required]
    public string LastName { get; set; }= String.Empty;
    [Required]
    public DateTime DateOfBirth { get; set; } 
}

public class MechanicTPO
{
    [Required]
    public int MechanicId { get; set; }
    [Required]
    public string LicenceNumber { get; set; }
}

public class ServiceTPO
{
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal ServiceFee { get; set; }
}