using Articles.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;

namespace Articles.Api.Configuration
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentException(nameof(services));

            services.AddAutoMapper(typeof(EntityToViewModelMapping), typeof(ViewModelToEntityMapping));
        }
    }
}
