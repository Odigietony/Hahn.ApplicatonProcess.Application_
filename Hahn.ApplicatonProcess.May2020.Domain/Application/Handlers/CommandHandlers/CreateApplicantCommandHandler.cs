using AutoMapper;
using Hahn.ApplicatonProcess.May2020.Domain.Application.Commands;
using Hahn.ApplicatonProcess.May2020.Domain.Domain.Repository;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Application.Handlers.CommandHandlers
{
    public class CreateApplicantCommandHandler : IRequestHandler<CreateApplicantCommand, int>
    {
        private readonly IApplicationRepository _applicantRepository;
        private readonly ILogger<CreateApplicantCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly int _failed = -1;

        public CreateApplicantCommandHandler(IApplicationRepository applicationRepository,IMapper mapper, 
            ILogger<CreateApplicantCommandHandler> logger)
        {
            _applicantRepository = applicationRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = _mapper.Map<Applicant>(request); 
            if(await _applicantRepository.Create(applicant))
            {
                _logger.LogInformation($"Created applicant with Id: { applicant.ID }.");
                return applicant.ID;
            } 
            return _failed;
        }
    }
}
