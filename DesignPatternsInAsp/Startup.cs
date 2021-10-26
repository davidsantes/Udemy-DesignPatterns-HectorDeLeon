using DesignPatternsInAsp.Configuration;
using DesignPatternsInAsp.Models.Data;
using DesignPatternsInAsp.Repository.Repository;
using DesignPatternsInAsp.Repository.UnitOfWork;
using DesignPatternsInAsp.Tools.Factory;
using DesignPatternsInAsp.Tools.Generator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DesignPatternsInAsp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            
            //Inyección de las configuraciones de appsettings.json
            services.Configure<MyCustomConfig>(Configuration.GetSection("MyCustomConfig"));

            //Inyección de dependencias, inyectamos en el contenedor las factorías
            services.AddTransient((factory)=> { 
                return new LocalEarnFactory(Configuration.GetSection("MyCustomConfig").GetValue<decimal>("LocalPercentage"));
            });
            services.AddTransient((factory) => {
                return new ForeignEarnFactory(Configuration
                    .GetSection("MyCustomConfig").GetValue<decimal>("ForeignPercentage"),
                    Configuration
                    .GetSection("MyCustomConfig").GetValue<decimal>("Extra"));
            });
            services.AddDbContext<InventoryDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Connection"));
            });

            //A diferencia de Singleton, en este caso devuelve un objeto por cada solicitud
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //No se utiliza la intefaz porque internamente se puede crear con un elemento no asociado a la interfaz (Generator)
            services.AddScoped<GeneratorConcreteBuilder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
