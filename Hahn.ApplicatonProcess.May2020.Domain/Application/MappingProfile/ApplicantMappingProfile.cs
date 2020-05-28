using AutoMapper;
using Hahn.ApplicatonProcess.May2020.Domain.Application.Commands;
using Hahn.ApplicatonProcess.May2020.Domain.Application.Dto;
using Hahn.ApplicatonProcess.May2020.Domain.Dto;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Domain.Application.MappingProfile
{
    public class ApplicantMappingProfile : Profile
    {
        public ApplicantMappingProfile()
        {
            CreateMap<Applicant, ApplicantDto>().ReverseMap();
            CreateMap<Applicant, CreateApplicantDto>().ReverseMap();
            CreateMap<Applicant, UpdateApplicantDto>().ReverseMap();
            CreateMap<Applicant, CreateApplicantCommand>().ReverseMap();
            CreateMap<Applicant, UpdateApplicantCommand>().ReverseMap();

            CreateMap<CreateApplicantCommand, CreateApplicantDto>().ReverseMap();
            CreateMap<UpdateApplicantCommand, UpdateApplicantDto>().ReverseMap();
             
        
 
        }
    }
}
