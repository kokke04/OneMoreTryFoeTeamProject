namespace OneMoreTryFoeTeamProject.Models.DtoModels
{
    public class Candidatedto
    {
       

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public string? NativeLanguage { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Email { get; set; }

        public string? LandlineNumber { get; set; }

        public string? MobileNumber { get; set; }

        public int? UserId { get; set; }

        //edw xrisimopoiume ts dto classes gia na  min exoume thema me ta json poumas dinei
        // episis den theloume i vasi na epikoinwnei me tn xristti ara mallon etsi gienatai

        public virtual ICollection<CandidateAddressdto> CandidateAddresses { get; set; } = new List<CandidateAddressdto>();

        public virtual ICollection<CandidatePhotoIddto> CandidatePhotoIds { get; set; } = new List<CandidatePhotoIddto>();

        public virtual ICollection<Certificatedto> Certificates { get; set; } = new List<Certificatedto>();

        //public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

        //public virtual ICollection<ExamVoucher> ExamVouchers { get; set; } = new List<ExamVoucher>();

        //public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

        //public virtual Usertbl? User { get; set; }
    }
}
