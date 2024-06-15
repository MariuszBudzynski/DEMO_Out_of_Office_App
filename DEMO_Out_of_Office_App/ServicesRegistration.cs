using DEMOOutOfOfficeApp.Core.Context;
using Microsoft.EntityFrameworkCore;
using DEMOOutOfOfficeApp.Core.Repository.Interfaces;
using DEMOOutOfOfficeApp.Core.Repository;
using DEMOOutOfOfficeApp.Core.UseCases;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.Helpers;
using DEMOOutOfOfficeApp.Helpers.Interfaces;

namespace DEMOOutOfOfficeApp
{
    public static class ServicesRegistration
	{
		public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddRazorPages();

			services.AddRazorPages(options =>
			{
                options.Conventions.AuthorizeFolder("/");
				options.Conventions.AllowAnonymousToPage("/Login");
			});

            services.AddAuthentication("CookieAuthentication")
			.AddCookie("CookieAuthentication", config =>
			{
				config.Cookie.Name = "UserLoginCookie";
				config.LoginPath = "/Login";
                config.ExpireTimeSpan = TimeSpan.FromMinutes(20); // expiration time
                config.SlidingExpiration = true; //the cookie expiration time should be reset every time
												 //the client sends a request before the cookie expiration time expires.
                config.Cookie.IsEssential = true; // or compliance with legal regulations, e.g. GDPR
            });

            services.AddDbContext<AppDbContext>(options => 
			
				options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection"))
			);

			services.AddScoped<IRepository, Repository>();
			services.AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
			services.AddScoped<IGetAllEmployeesUseCase, GetAllEmployeesUseCase>();
			services.AddScoped<IGetDataByIdUseCase, GetDataByIdUseCase>();
			services.AddScoped<IUpdateEmployeeUseCase, UpdateEmployeeUseCase>();
			services.AddScoped<IGetAllSubdivisionsUseCase, GetAllSubdivisionUseCase>();
			services.AddScoped<IGetAllPositionsUseCase,GetAllPositionsUseCase>();
			services.AddScoped<IGetAllRolesUseCase, GetAllRolesUseCase>();
			services.AddScoped<IGetAllStatusesUseCase, GetAllStatusesUseCase>();
			services.AddScoped<ISaveSingleEmployeeUseCase, SaveSingleEmployeeUseCase>();
			services.AddScoped<IDataLoaderHelper, DataLoaderHelper>();
        }
	}
}
