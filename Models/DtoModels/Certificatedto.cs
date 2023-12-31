namespace OneMoreTryFoeTeamProject.Models.DtoModels
{
    public class Certificatedto
    {
       // public int CertificateId { get; set; }

        public string? Title { get; set; }

        public int? CandidateId { get; set; }

        public string? AssessmentTestCode { get; set; }

        public DateTime? ExaminationDate { get; set; }

        public DateTime? ScoreReportDate { get; set; }

        public int? CandidateScore { get; set; }

        public int? MaximumScore { get; set; } 

        public double? PercentageScore { get; set; }

        public string? AssessmentResultLabel { get; set; }

        public virtual ICollection<CertificateTopicMarksdto> CertificateTopicMarks { get; set; } = new List<CertificateTopicMarksdto>();

       // public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();
    }
}
