namespace BoxTI.DojoIntegrado.Services.DTOs;

public class CompanyDTO
{
    public int Id { get; set; }
    public string Phone { get; set; }
    public string CorporateName { get; set; }
    public string FantasyName { get; set; }
    public string Cnpj { get; set; }
    public string Description { get; set; }
    public AddressDTO AddressDTO { get; set; }
}
