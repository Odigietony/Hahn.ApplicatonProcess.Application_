using Hahn.ApplicatonProcess.May2020.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Application.Commands
{
    public class UpdateApplicantCommand : UpdateApplicantDto, IRequest<UpdateApplicantDto>
    {
        public UpdateApplicantCommand()
        {

        }
    }
}
