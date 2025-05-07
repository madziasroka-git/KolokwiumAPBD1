namespace KOLOS1.DTOs;

public class CreateVisitTPO
{
    public int VisitID { get; set; }
    public int ClientID { get; set; }
    public string MechanicLicence { get; set; }
    public List<ServicesTPO> Services { get; set; }
}

public class ServicesTPO
{
    public string ServiceName { get; set; }
    public decimal ServiceFee { get; set; }
}