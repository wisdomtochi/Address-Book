using Address_Book.Data;
using Address_Book.Data_Access.Implementations;
using Address_Book.Data_Access.Interfaces;
using Address_Book.Services.Implementation;
using Address_Book.Services.Interfaces;
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

            services.AddMvc(options => options.EnableEndpointRouting = false).AddXmlSerializerFormatters();
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
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
