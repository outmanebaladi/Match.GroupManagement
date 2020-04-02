using System;
using Match.GroupManagement.Business.Impl.Services;
using Match.GroupManagement.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IGroupsService, GroupsService>();
            return services;
        }
        
    }
}
