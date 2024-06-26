﻿namespace DEMOOutOfOfficeApp
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
                options.Conventions.AuthorizePage("/Projects", "EmployeeHRPMAdminPolicy");
                options.Conventions.AuthorizePage("/LeaveRequests", "EmployeeHRPMAdminPolicy");
                options.Conventions.AuthorizePage("/ApprovalRequests", "HRPMAdminPolicy");
                options.Conventions.AuthorizePage("/Employees", "HRPMAdminPolicy");
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("EmployeeHRPMAdminPolicy", policy =>
                    policy.RequireRole("Employee", "HRManager", "ProjectManager", "Administrator"));

                options.AddPolicy("HRPMAdminPolicy", policy =>
                    policy.RequireRole("HRManager", "ProjectManager", "Administrator"));
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
			services.AddScoped<IGetAllRolesUseCase, GetAllRolesUseCase>();
			services.AddScoped<IGetAllStatusesUseCase, GetAllStatusesUseCase>();
			services.AddScoped<ISaveSingleEmployeeUseCase, SaveSingleEmployeeUseCase>();
			services.AddScoped<IDataLoaderHelper, DataLoaderHelper>();
			services.AddScoped<IGetAprovalRequestsUseCase, GetAprovalRequestsUseCase>();
			services.AddScoped<IGetLeaveRequestsUseCase, GetLeaveRequestsUseCase>();
			services.AddScoped<IGetDataUseCase, GetDataUseCase>();
			services.AddScoped<IGetProjectsUseCase, GetProjectsUseCase>();
			services.AddScoped<IUpdateLeaveRequestUseCase, UpdateLeaveRequestUseCase>();
			services.AddScoped<IUpdateAprovalRequestUseCase, UpdateAprovalRequestUseCase>();
			services.AddScoped<IDataLoaderHelper,DataLoaderHelper>();
			services.AddScoped<ISaveLeaveRequestDataUseCase, SaveLeaveRequestDataUseCase>();
			services.AddScoped<IGetEmployeeProjectsUseCase, GetEmployeeProjectsUseCase>();
			services.AddScoped<ISaveListOfObjectsToDatabaseUseCase, SaveListOfObjectsToDatabaseUseCase>();
			services.AddScoped<IUpdateProjectDataUseCase, UpdateProjectDataUseCase>();
			services.AddScoped<ISaveDataUseCase, SaveDataUseCase>();
			services.AddScoped<IGetAprovalRequestsByIdUseCase, GetAprovalRequestsByIdUseCase>();
			services.AddScoped<ISaveOrUpdateProjectEmployeeUseCase, SaveOrUpdateProjectEmployeeUseCase>();
        }
	}
}
