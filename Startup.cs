using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWebsight.Models;
using Microsoft.EntityFrameworkCore;

namespace MyWebsight
{
    public class Startup
    {
        private string _connectionString = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //dotnet user-secrets set secretConnectionString "User ID=pdev;Password=pdev;Server=localhost;Port=5432;Database=Advantage.API.Dev;Integrated Security=true;Pooling=true;"
            //dotnet ef migrations add InitialMigration
            //dotnet ef database update
            _connectionString = Configuration["secretConnectionString"];
            services.AddMvc();
            services.AddEntityFrameworkNpgsql()
            .AddDbContext<ApiContext>(
                opt => opt.UseNpgsql(_connectionString));

            services.AddTransient<DataSeed> ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataSeed seed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            seed.SeedData (20, 1000);

            app.UseMvc();
        }
    }
}