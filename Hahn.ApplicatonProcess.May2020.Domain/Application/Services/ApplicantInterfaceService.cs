using AutoMapper;
using Hahn.ApplicatonProcess.May2020.Application.Interfaces;
using Hahn.ApplicatonProcess.May2020.Domain.Application.Commands;
using Hahn.ApplicatonProcess.May2020.Domain.Application.Dto;
using Hahn.ApplicatonProcess.May2020.Domain.Application.Queries;
using Hahn.ApplicatonProcess.May2020.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Application.Services
{
    public class ApplicantInterfaceService : IApplicantInterface
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ApplicantInterfaceService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        } 

        public async Task<int> Create(CreateApplicantDto applicantDto)
        { 
            return await _mediator.Send(_mapper.Map<CreateApplicantCommand>(applicantDto));
        }

        public async Task<bool> Delete(int applicantId)
        {
            DeleteApplicantCommand command = new DeleteApplicantCommand(applicantId);
            return await _mediator.Send(command);
        }

        public async Task<ApplicantDto> Find(int applicantId)
        {
            var query = new GetApplicantByIdQuery(applicantId);
            var result = await _mediator.Send(query);
            return result;
        }

        public ICollection<ApplicantDto> Read()
        {
            throw new NotImplementedException();
        } 

        public async Task<UpdateApplicantDto> Update(int applicantId, UpdateApplicantDto applicanDto)
        {
            if (applicanDto == null || applicantId != applicanDto.Id) return null;
            var entity = _mapper.Map<UpdateApplicantCommand>(applicanDto); 
            return await _mediator.Send(entity);
        }
    }
}
