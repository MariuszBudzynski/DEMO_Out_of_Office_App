using Azure;
using System;
using DEMOOutOfOfficeApp.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace DEMOOutOfOfficeApp
{
	public static class ServicesRegistration
	{
		public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddRazorPages();
			services.AddDbContext<AppDbContext>(options => 
			
				options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection"))
			);
		}
	}
}
