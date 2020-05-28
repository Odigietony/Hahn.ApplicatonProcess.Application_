using Hahn.ApplicatonProcess.May2020.Domain.Domain.Repository;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Data.Repository
{
    public class ApplicantRepository : IApplicationRepository
    {
        private readonly DataContext _context;

        public ApplicantRepository(DataContext context)
        {
            _context = context;
        } 

        public async Task<bool> Create(Applicant applicant)
        {
            await _context.Applicants.AddAsync(applicant);
            return Save();
        }

        public bool Delete(Applicant applicant)
        {
            _context.Remove(applicant);
            return Save();
        }
        
        public async Task<Applicant> Find(int applicantId)
        {
            return await _context.Applicants.FindAsync(applicantId);
        }

        public ICollection<Applicant> Read()
        {
            return _context.Applicants.ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() > -1 ? true : false;
        }

        public bool Update(Applicant applicant)
        {
            _context.Applicants.Update(applicant);
            return Save();
        }
    }
}
