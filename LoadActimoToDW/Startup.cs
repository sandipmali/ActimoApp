using Actimo.Business.DataFactory;
using Actimo.Business.DataProvider;
using Actimo.Business.Engines;
using Actimo.Business.Engines.Interfaces;
using Actimo.Business.Managers;
using Actimo.Business.Services;
using Actimo.Data.Accesor;
using Actimo.Data.Accesor.Repository;
using Actimo.Data.Accesor.Repository.Interface;
using LoadActimoToDW;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

[assembly: FunctionsStartup(typeof(Startup))]
namespace LoadActimoToDW
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IDataFeedManager, DataFeedManager>();
            builder.Services.AddScoped<IInputDataProvider, InputDataProvider>();
            builder.Services.AddScoped<IContactDataEngine, ContactDataEngine>();
            builder.Services.AddScoped<IContactMangerDataEngine, ContactMangerDataEngine>();
            builder.Services.AddScoped<IEngagementDataEngine, EngagementDataEngine>();

            builder.Services.AddScoped<IActimoDataFactory, ActimoDataFactory>();
            builder.Services.AddScoped<IRestClientService, RestClientService>();

            builder.Services.AddDbContext<DWContext>(options =>
               options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.Process)
                                    ?? throw new InvalidOperationException()));

            builder.Services.AddScoped<IClientLookupRepository, ClientLookupRepository>();
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IContactManagerRepository, ContactManagerRepository>();
        }
    }
}
