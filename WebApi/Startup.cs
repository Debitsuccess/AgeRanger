using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

using WebApi.Domain;
using WebApi.Repositories;
using WebApi.Repositories.InMemory;
using WebApi.Services;

namespace WebApi
{
// ReSharper disable once ClassNeverInstantiated.Global
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

			if (env.IsDevelopment())
			{
				// This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
				builder.AddApplicationInsightsSettings(developerMode: true);
			}

			builder.AddEnvironmentVariables();
			Configuration = builder.Build();
		}


// ReSharper disable once MemberCanBePrivate.Global
		public IConfigurationRoot Configuration { get; }


		// This method gets called by the runtime.  Use this method to add services to the container.
// ReSharper disable once UnusedMember.Global
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddApplicationInsightsTelemetry(Configuration);

			services.AddMvc();


			services.Add(
				new[]
				{
					new ServiceDescriptor(typeof(IRepository<int, AgeGroup>), new AgeGroupRepository()),
					new ServiceDescriptor(typeof(IWritableRepository<int, Person>), new PersonWritableRepository()),

					new ServiceDescriptor(typeof(IAgeGroupService), typeof(AgeGroupService), ServiceLifetime.Scoped),
					new ServiceDescriptor(typeof(IPersonService), typeof(PersonService), ServiceLifetime.Scoped)
				}
			);
		}

		// This method gets called by the runtime.  Use this method to configure the HTTP request pipeline.
// ReSharper disable once UnusedMember.Global
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseApplicationInsightsRequestTelemetry();

			app.UseApplicationInsightsExceptionTelemetry();

			app.UseMvc();
		}
	}
}
