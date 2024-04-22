using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Sample.DAL.Context;
using Sample.DAL.ReadRepositories;
using Sample.DAL.WriteRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DAL
{
    public static class SampleDalConfiguration
    {
        public static IServiceCollection SampleDalRegisterConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=SampleCqrs;User Id=sa;Password=12345;Integrated Security=false;Trusted_Connection=true;TrustServerCertificate=True");
            });

            services.AddScoped<WriteMovieRepository>();
            services.AddScoped<DirectorRepository>();
            services.AddScoped<ReadMovieRepository>();

            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase("moviesdatabase");
            services.AddSingleton(mongoDatabase);

            return services;
        }
    }
}
