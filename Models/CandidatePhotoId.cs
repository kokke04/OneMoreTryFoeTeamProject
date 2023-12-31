using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OneMoreTryFoeTeamProject.Models;

public partial class CandidatePhotoId
{
   
    public int PhotoId { get; set; }
   
    public int? CandidateId { get; set; }

    public string? PhotoIdtype { get; set; }

    public string? PhotoIdnumber { get; set; }

    public DateTime? PhotoIdissueDate { get; set; }
    [JsonIgnore]
    public virtual Candidate? Candidate { get; set; }
}
