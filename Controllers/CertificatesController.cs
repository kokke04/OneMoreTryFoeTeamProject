using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneMoreTryFoeTeamProject.Models;
using OneMoreTryFoeTeamProject.Models.DtoModels;
using OneMoreTryFoeTeamProject.Services;

namespace OneMoreTryFoeTeamProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CertificatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Certificates
        [HttpGet]
        public IActionResult GetCertificates()
        {
          if (_context.Certificates == null)
          {
              return NotFound();
          }
            var certs = _context.Certificates
          .Select(c => new
          {
              CertificateId = c.CertificateId,
              Title = c.Title,
              MaximumScore = c.MaximumScore
              // Add other properties you want to include
          })
          .ToList();
            return Ok(certs);
        }

        // GET: api/Certificates/5
        [HttpGet("{id}")]
        public IActionResult GetCertificate(int id)
        {
          if (_context.Certificates == null)
          {
              return NotFound();
          }
            var certificate = _context.Certificates.Find(id);

            if (certificate == null)
            {
                return NotFound();
            }

            return Ok(certificate);
        }

        // PUT: api/Certificates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificate(int id, Certificatedto certificatedto)
        {

            var certificate = _context.Certificates.SingleOrDefault(c => c.CandidateId == id);


            if (certificate == null)
            {
                return NotFound();
            }

            _context.Entry(certificatedto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Certificates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostCertificate(Certificatedto certificatedto)
        {
            Certificate certificate = new Certificate()
            {

                Title = certificatedto.Title,
                CandidateId = certificatedto.CandidateId,
                AssessmentTestCode = certificatedto.AssessmentTestCode,
                ExaminationDate = certificatedto.ExaminationDate,
                ScoreReportDate = certificatedto.ScoreReportDate,
                CandidateScore = certificatedto.CandidateScore,
                MaximumScore = certificatedto.MaximumScore,
                PercentageScore = certificatedto.PercentageScore,
                AssessmentResultLabel = certificatedto.AssessmentResultLabel      

            };

            _context.Certificates.Add(certificate);
            _context.SaveChanges();
            return Ok(certificate);
        }

        // DELETE: api/Certificates/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCertificate(int id)
        {
            if (_context.Certificates == null)
            {
                return NotFound();
            }
            var certificate =  _context.Certificates.Find(id);
            if (certificate == null)
            {
                return NotFound();
            }

            _context.Certificates.Remove(certificate);
            _context.SaveChanges();

            return Ok(certificate);
        }

        private bool CertificateExists(int id)
        {
            return (_context.Certificates?.Any(e => e.CertificateId == id)).GetValueOrDefault();
        }
    }
}
