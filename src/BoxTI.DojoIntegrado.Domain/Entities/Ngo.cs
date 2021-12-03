namespace BoxTI.DojoIntegrado.Domain.Entities;

public class Ngo
{
    public int Id { get; set; }
    public int OrganizationId { get; set; }
    public Organization Organization { get; set; }
}