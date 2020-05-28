using Hahn.ApplicatonProcess.May2020.Application.Interfaces;
using Hahn.ApplicatonProcess.May2020.Data.Repository;
using Hahn.ApplicatonProcess.May2020.Domain.Application.Services;
using Hahn.ApplicatonProcess.May2020.Domain.Domain.Repository; 
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Data.IoC
{
    // @TODO delete this class.
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer
            services.AddScoped<IApplicantInterface, ApplicantInterfaceService>();

            //Domain repository and Infrastructure Data courseRepository implementation Layer
            services.AddScoped<IApplicationRepository, ApplicantRepository>(); 

            ////Domain InMemoryBus MediatR
            //services.AddScoped<IMediatorHandler, InMemoryBus>();

            ////Domain Handlers
            //services.AddScoped<IRequestHandler<CreateCourseCommand, bool>, CourseCommandHandler>();

        }
    }
}
