using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneMoreTryFoeTeamProject.Models.DtoModels;
using OneMoreTryFoeTeamProject.Models;
using OneMoreTryFoeTeamProject.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace OneMoreTryFoeTeamProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
            private readonly ApplicationDbContext context;

            public CandidatesController(ApplicationDbContext context)
            {
                this.context = context;
            }

            // GET: api/<CandidatesController>
            [HttpGet]
            public IActionResult GetCandidates()
            {

            var candidatesWithAddresses = context.Candidates.Include(c => c.CandidateAddresses);
            return Ok(candidatesWithAddresses);

            //var candidatesWithRelatedData = context.Candidates
            //    .Include(c => c.CandidatePhotoIds)
            //    .Include(c => c.Certificates)
            //    .Include(c => c.ExamResults)
            //    .Include(c => c.ExamVouchers)
            //    .Include(c => c.Exams)
            //    .Include(c => c.User) // Include user if necessary
            //    .Include(c => c.CandidateAddresses);

            //return Ok(candidatesWithRelatedData);


            //return Ok(context.Candidates);
            }

            // GET api/<CandidatesController>/5
            [HttpGet("{id}")]
            public IActionResult GetCandidate(int id)
            {
            var candid = context.Candidates
            .Include(c => c.CandidatePhotoIds)
            .Include(c => c.Certificates)
            .Include(c => c.ExamResults)
            .Include(c => c.ExamVouchers)
            .Include(c => c.Exams)
            .Include(c => c.User) // Include user if necessary
            .Include(c => c.CandidateAddresses)
            .FirstOrDefault(c => c.CandidateId == id);

            if (candid == null)
            {
                return NotFound();
            }

            return Ok(candid);
        }

            // POST api/<CandidatesController>
            [HttpPost]
            public IActionResult CreateCandidate(Candidatedto candidatedto)
            {
                Candidate candid = new Candidate()
                {
                    FirstName = candidatedto.FirstName,
                    MiddleName = candidatedto.MiddleName,
                    LastName = candidatedto.LastName,
                    Gender = candidatedto.Gender,
                    NativeLanguage = candidatedto.NativeLanguage,
                    BirthDate = candidatedto.BirthDate,
                    Email = candidatedto.Email,
                    LandlineNumber = candidatedto.LandlineNumber,
                    MobileNumber = candidatedto.MobileNumber,
                    //Certificates= candidatedto.Certificates,
                    //ExamVouchers= candidatedto.ExamVouchers,
                    //ExamResults= candidatedto.ExamResults,
                    //Exams = candidatedto.Exams,
                };



            candid.CandidateAddresses = candidatedto.CandidateAddresses
            .Select(addressDto => new CandidateAddress
            {
                Address = addressDto.Address,
                AddressLine2 = addressDto.AddressLine2,
                CountryOfResidence = addressDto.CountryOfResidence,
                StateTerritoryProvince = addressDto.StateTerritoryProvince,
                TownCity = addressDto.TownCity,
                PostalCode = addressDto.PostalCode
            }).ToList();

            candid.CandidatePhotoIds = candidatedto.CandidatePhotoIds
                .Select(photoIdDto => new CandidatePhotoId
                {
                    PhotoIdtype = photoIdDto.PhotoIdtype,
                    PhotoIdnumber = photoIdDto.PhotoIdnumber,
                    PhotoIdissueDate = photoIdDto.PhotoIdissueDate
                }).ToList();

             candid.Certificates = candidatedto.Certificates
                .Select(certsDto => new Certificate
                {
                    //CertificateId = certsDto.CertificateId
                    Title = certsDto.Title,
                    AssessmentTestCode = certsDto.AssessmentTestCode,
                    ExaminationDate = certsDto.ExaminationDate,
                    ScoreReportDate = certsDto.ScoreReportDate,
                    CandidateScore = certsDto.CandidateScore,
                    MaximumScore = certsDto.MaximumScore,
                    PercentageScore = certsDto.PercentageScore,
                    AssessmentResultLabel = certsDto.AssessmentResultLabel
                }).ToList();

            //// Fetch the existing Certificate from the database based on the provided CertificateId
            //var existingCertificate = context.Certificates
            //    .FirstOrDefault(c => c.CertificateId == candidatedto.CertificateId);

            //// Check if the certificate exists
            //if (existingCertificate != null)
            //{
            //    // Associate the existing certificate with the candidate
            //    candid.Certificates.Add(existingCertificate);
            //}

            context.Candidates.Add(candid);
                context.SaveChanges();
                return Ok(candid);
            }

     
        // PUT api/<CandidatesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateCandidate(int id, Candidatedto candidatedto)
        {
            var candidate = context.Candidates
                .Include(c => c.CandidateAddresses) // Include related CandidateAddresses
                .Include(c => c.CandidatePhotoIds)   // Include related CandidatePhoitiIds
                .SingleOrDefault(c => c.CandidateId == id);
            //var candidate = context.Candidates.Find(id);
            if (candidate == null)
            {
                return NotFound();
            }
            candidate.FirstName = candidatedto.FirstName;
            candidate.MiddleName = candidatedto.MiddleName;
            candidate.LastName = candidatedto.LastName;
            candidate.Gender = candidatedto.Gender;
            candidate.NativeLanguage = candidatedto.NativeLanguage;
            candidate.BirthDate = candidatedto.BirthDate;
            candidate.LandlineNumber = candidatedto.LandlineNumber;
            candidate.MobileNumber = candidatedto.MobileNumber;


            candidate.CandidateAddresses = candidatedto.CandidateAddresses
            .Select(addressDto => new CandidateAddress
            {
                Address = addressDto.Address,
                AddressLine2 = addressDto.AddressLine2,
                CountryOfResidence = addressDto.CountryOfResidence,
                StateTerritoryProvince = addressDto.StateTerritoryProvince,
                TownCity = addressDto.TownCity,
                PostalCode = addressDto.PostalCode
            }).ToList();

            candidate.CandidatePhotoIds = candidatedto.CandidatePhotoIds
                .Select(photoIdDto => new CandidatePhotoId
                {
                    PhotoIdtype = photoIdDto.PhotoIdtype,
                    PhotoIdnumber = photoIdDto.PhotoIdnumber,
                    PhotoIdissueDate = photoIdDto.PhotoIdissueDate
                }).ToList();

            /*candidate.Certificates = candidatedto.Certificates
                .Select(certsDto => new Certificate
                {
                    
                    Title = certsDto.Title,
                    AssessmentTestCode = certsDto.AssessmentTestCode,
                    ExaminationDate = certsDto.ExaminationDate,
                    ScoreReportDate = certsDto.ScoreReportDate,
                    CandidateScore = certsDto.CandidateScore,
                    MaximumScore = certsDto.MaximumScore,
                    PercentageScore = certsDto.PercentageScore,
                    AssessmentResultLabel = certsDto.AssessmentResultLabel
                }).ToList();*/

            context.SaveChanges();
            return Ok(candidate);


        }

        // DELETE api/<CandidatesController>/5
        [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var candidate = context.Candidates
                .Include(c => c.CandidateAddresses) // Include related CandidateAddresses
                .Include(c=> c.CandidatePhotoIds)   // Include related CandidatePhoitiIds
                .Include(c=> c.Certificates)
                .SingleOrDefault(c => c.CandidateId == id);

                if (candidate == null)
                {
                    return NotFound();
                }

                context.Certificates.RemoveRange(candidate.Certificates);
                context.CandidateAddresses.RemoveRange(candidate.CandidateAddresses);
                context.CandidatePhotoIds.RemoveRange(candidate.CandidatePhotoIds);
                context.Candidates.Remove(candidate);
                context.SaveChanges();
                return Ok(candidate);

            }

    }
}
