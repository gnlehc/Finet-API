using Finet.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Finet
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
            services.AddDbContext<FinetContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Finet"));
                options.EnableSensitiveDataLogging();
            });

            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .WithOrigins("http://10.0.2.2:5000")
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowSpecificOrigin");
        }
    }
}
