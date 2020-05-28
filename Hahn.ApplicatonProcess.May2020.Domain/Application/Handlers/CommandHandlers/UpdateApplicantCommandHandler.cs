using AutoMapper;
using Hahn.ApplicatonProcess.May2020.Domain.Application.Commands;
using Hahn.ApplicatonProcess.May2020.Domain.Domain.Repository;
using Hahn.ApplicatonProcess.May2020.Domain.Dto;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Application.Handlers.CommandHandlers
{
    public class UpdateApplicantCommandHandler : IRequestHandler<UpdateApplicantCommand, UpdateApplicantDto>
    {
        private readonly IApplicationRepository _applicantRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateApplicantCommandHandler(IApplicationRepository applicantRepository, IMapper mapper,
            ILogger<UpdateApplicantCommandHandler> logger)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<UpdateApplicantDto> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {  
            var applicantDto = _mapper.Map<UpdateApplicantDto>(request); 
            var result = _applicantRepository.Update(_mapper.Map<Applicant>(request)) ? applicantDto : null;
            if(result != null)
            {
                _logger.LogInformation($"Updated applicant {result.Name} with Id: {request.Id }.");
            }
            return await Task.FromResult(result);
        }
    }
}
