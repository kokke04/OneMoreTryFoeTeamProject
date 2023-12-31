using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OneMoreTryFoeTeamProject.Models;

public partial class CandidateAddress
{
    
    public int AddressId { get; set; }

    public int? CandidateId { get; set; }

    public string? Address { get; set; }

    public string? AddressLine2 { get; set; }

    public string? CountryOfResidence { get; set; }

    public string? StateTerritoryProvince { get; set; }

    public string? TownCity { get; set; }

    public string? PostalCode { get; set; }

    [JsonIgnore]
    public virtual Candidate? Candidate { get; set; }
}
