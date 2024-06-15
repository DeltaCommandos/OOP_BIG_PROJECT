using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OOP_BIG_PROJECT.Models;

namespace OOP_BIG_PROJECT
{
    public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));

			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationContext>();

			services.AddControllersWithViews();
		}
	}
}
