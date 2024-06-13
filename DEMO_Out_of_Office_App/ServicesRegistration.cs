using Azure;

namespace DEMOOutOfOfficeApp
{
	public static class ServicesRegistration
	{
		public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddRazorPages();

		}
	}
}
