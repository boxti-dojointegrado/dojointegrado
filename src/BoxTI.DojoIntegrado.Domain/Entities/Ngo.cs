namespace BoxTI.DojoIntegrado.Domain.Entities;

public class Ngo
{
    public int OrganizationId { get; set; }
    public virtual Organization Organization { get; set; }
}