namespace BoxTI.DojoIntegrado.Domain.Entities;

public class Organization : BaseEntity
{
    public int AddressId { get; set; }
    public Address Address { get; set; }
    public string Phone { get; set; }
    public string CorporateName { get; set; }
    public string FantasyName { get; set; }
    public string Cnpj { get; set; }
    public string Description { get; set; }
}