using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Application.Commands
{
    public class DeleteApplicantCommand : IRequest<bool>
    {
        public int Id { get;}
        public DeleteApplicantCommand(int applicantId)
        {
            Id = applicantId;
        }
    }
}
