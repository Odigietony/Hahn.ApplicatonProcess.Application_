using Hahn.ApplicatonProcess.May2020.Domain.Application.Dto;
using Hahn.ApplicatonProcess.May2020.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Application.Interfaces
{
    public interface IApplicantInterface
    {
        Task<int> Create(CreateApplicantDto applicant);
        ICollection<ApplicantDto> Read();
        Task<ApplicantDto> Find(int applicantId);
        Task<UpdateApplicantDto> Update(int applicantId, UpdateApplicantDto applicantDto);
        Task<bool> Delete(int applicantId);  
    }
}
