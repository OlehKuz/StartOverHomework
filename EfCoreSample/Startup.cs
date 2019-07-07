using EfCoreSample.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration.UserSecrets;
using EfCoreSample.Infrastructure;

using System.IO;

namespace EfCoreSample
{
    public class Startup
    {
        public Startup()
        {
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true);
            
                builder.AddUserSecrets<EfCoreSampleDbContext>();
            Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; set; }
         

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

           
            services.AddDbContext<EfCoreSampleDbContext>(options =>
                options.UseMySql(Configuration["ConnectionStrings:LocalConnection"]));
            services.AddScoped<IRepository, BaseRepository>();
            services.AddScoped<IService, Service>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, EfCoreSampleDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.EnsureContextMigrated<EfCoreSampleDbContext>();
            //TODO change this seed method, remove EfCoreSampleDbContext from configure method
            //SeedDb.Initialize(context);//ContextSeed.SeedAsync(app).Wait();
        }
    }
}
