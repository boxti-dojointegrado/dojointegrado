﻿namespace BoxTI.DojoIntegrado.Domain.Entities;

public class Address : BaseEntity
{
    public string StreetName { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Neighborhood { get; set; }
    public virtual Organization Organization { get; set; }
}