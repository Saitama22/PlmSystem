using System;
using System.IO;
using System.Linq;
using System.Reflection;
using PlmSystem.Models.DbContexts;
using PlmSystem.Models.Handlers;
using PlmSystem.Models.Intarfaces.DbContexts;
using PlmSystem.Models.Intarfaces.Handlers;
using PlmSystem.Models.Intarfaces.Repositories;
using PlmSystem.Models.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace PlmSystem
{
	public static class DI
	{
		public static IServiceCollection Init(this IServiceCollection services)
		{
			services.AddSwaggerGen();

			services.AddMvc();
			services.AddControllers()
				.AddNewtonsoftJson(options =>
					options.SerializerSettings.ReferenceLoopHandling =  ReferenceLoopHandling.Ignore);
			services.AddDbContext();
			services.AddRepos();
			services.AddHandlers(); 
			
			return services;
		}

		private static IServiceCollection AddDbContext(this IServiceCollection services)
		{
			services.AddDbContext<JiraDbContext>();
			return services;
		}

		private static IServiceCollection AddRepos(this IServiceCollection services)
		{
			services.AddScoped<IProjectRepo, ProjectRepo>();
			services.AddScoped<ITaskStateRepo, TaskStateRepo>();
			services.AddScoped<ITaskJiraRepo, TaskJiraRepo>();
			return services;
		}

		private static IServiceCollection AddHandlers(this IServiceCollection services)
		{
			services.AddScoped<IProjectHandler, ProjectHandler>();
			return services;
		}
		public static IServiceCollection RemoveService<T>(this IServiceCollection services)
		{
			if (services.IsReadOnly)
			{
				throw new Exception($"{nameof(services)} is read only");
			}

			var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(T));
			if (serviceDescriptor != null) services.Remove(serviceDescriptor);

			return services;
		}		
	}
}
