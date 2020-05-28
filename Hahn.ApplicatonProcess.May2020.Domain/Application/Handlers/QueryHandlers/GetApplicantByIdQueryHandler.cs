using AutoMapper;
using Hahn.ApplicatonProcess.May2020.Domain.Application.Dto;
using Hahn.ApplicatonProcess.May2020.Domain.Application.Queries;
using Hahn.ApplicatonProcess.May2020.Domain.Domain.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Application.Handlers.QueryHandlers
{
    public class GetApplicantByIdQueryHandler : IRequestHandler<GetApplicantByIdQuery, ApplicantDto>
    {
        private readonly IApplicationRepository _applicantRepository;
        private readonly IMapper _mapper;
        public GetApplicantByIdQueryHandler(IApplicationRepository applicantRepository, IMapper mapper)
        {
            _mapper = mapper;
            _applicantRepository = applicantRepository;
        }
        public async Task<ApplicantDto> Handle(GetApplicantByIdQuery request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantRepository.Find(request.Id);
            if (applicant == null) return null;
            var applicantDto = _mapper.Map<ApplicantDto>(applicant);
            return applicantDto;
        }
    }
}
