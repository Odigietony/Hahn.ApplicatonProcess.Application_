using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Domain.Repository
{
    public interface IApplicationRepository
    {
        Task<bool> Create(Applicant applicant);
        ICollection<Applicant> Read();
        Task<Applicant> Find(int applicantId);
        bool Update(Applicant applicant);
        bool Delete(Applicant applicant);
        bool Save();
    }
}
