namespace BoxTI.DojoIntegrado.Domain.Entities;

public class Company
{
    public int OrganizationId { get; set; }
    public virtual Organization Organization { get; set; }
}
