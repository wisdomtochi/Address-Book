using Address_Book.Data.DataAccess.Implementations;
using Address_Book.Data.DataAccess.Interfaces;
using Address_Book.Data.DataContext;
using Address_Book.Services.Customers.Implementation;
using Address_Book.Services.Customers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Address_Book
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            this._config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AddressBookDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("CustomerDBConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AddressBookDbContext>();


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 7;
                options.Password.RequireUppercase = false;
            });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();
            //services.AddScoped<ICustomerRepository, SQLCustomerRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddControllers();
            services.AddControllersWithViews();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{Id?}");
            });
        }
    }
}
