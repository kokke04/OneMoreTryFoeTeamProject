using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OneMoreTryFoeTeamProject.Models;

public partial class Certificate
{
    public int CertificateId { get; set; }

    public string? Title { get; set; }

    public int? CandidateId { get; set; }

    public string? AssessmentTestCode { get; set; }

    public DateTime? ExaminationDate { get; set; }

    public DateTime? ScoreReportDate { get; set; }

    public int? CandidateScore { get; set; }

    public int? MaximumScore { get; set; }

    public double? PercentageScore { get; set; }

    public string? AssessmentResultLabel { get; set; }
    [JsonIgnore]
    public virtual Candidate? Candidate { get; set; }

    public virtual ICollection<CertificateTopicMark> CertificateTopicMarks { get; set; } = new List<CertificateTopicMark>();

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();
}
