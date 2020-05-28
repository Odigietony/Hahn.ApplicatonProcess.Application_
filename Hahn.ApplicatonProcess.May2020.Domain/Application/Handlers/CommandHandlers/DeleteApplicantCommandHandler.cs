using Hahn.ApplicatonProcess.May2020.Domain.Application.Commands;
using Hahn.ApplicatonProcess.May2020.Domain.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Application.Handlers.CommandHandlers
{
    public class DeleteApplicantCommandHandler : IRequestHandler<DeleteApplicantCommand, bool>
    {
        private readonly IApplicationRepository _applicantRepository;
        private readonly ILogger _logger;

        public DeleteApplicantCommandHandler(IApplicationRepository applicantRepository, ILogger<DeleteApplicantCommandHandler> logger)
        {
            _applicantRepository = applicantRepository;
            _logger = logger;
        }
        public async Task<bool> Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _applicantRepository.Find(request.Id);
            if (applicant == null) return false;
            string applicantName = applicant.Name;
            int applicantId = applicant.ID;
            var result = _applicantRepository.Delete(applicant) ? true : false;
            if(result)
            {
                _logger.LogInformation($"Deleted applicant with Name: { applicantName } and Id: {applicantId}");
            }
            return result;
        }
    }
}
