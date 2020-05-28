using Hahn.ApplicatonProcess.May2020.Domain.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Application.Queries
{
    public class GetApplicantByIdQuery : IRequest<ApplicantDto>
    {
        public int Id { get;}
        public GetApplicantByIdQuery(int applicantId)
        {
            this.Id = applicantId;
        }
    }
}
