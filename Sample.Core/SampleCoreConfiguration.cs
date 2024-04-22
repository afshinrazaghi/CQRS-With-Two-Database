using Microsoft.Extensions.DependencyInjection;
using Sample.Core.Common.BaseChannel;
using Sample.Core.MovieApplication.BackgroundWorker.AddReadMovie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core
{
    public static class SampleCoreConfiguration
    {
        public static IServiceCollection SampleCoreRegisterConfiguration(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ChannelQueue<>));
            services.AddHostedService<AddReadModelWorker>();
            services.AddMediatR(mediator => mediator.RegisterServicesFromAssembly(typeof(SampleCoreConfiguration).Assembly));
            return services;
        }
    }
}
