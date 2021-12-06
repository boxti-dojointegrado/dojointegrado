using System.ComponentModel.DataAnnotations.Schema;

namespace BoxTI.DojoIntegrado.Domain.Entities;

public class Organization : BaseEntity
{
    public string Phone { get; set; }
    public string CorporateName { get; set; }
    public string FantasyName { get; set; }
    public string Cnpj { get; set; }
    public string Description { get; set; }
    public int AddressId { get; set; }
    public virtual Address Address { get; set; }
    public virtual Ngo Ngo { get; set; }
    public virtual Company Company { get; set; }

    [NotMapped]
    public bool IsCompany { get; set; }
}