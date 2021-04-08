using AutoMapper;
using IdentityServer.Api.Configurations;
using IdentityServer.Api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace IdentityServer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            // use in-memory database
            //ConfigureInMemoryDatabases(services);

            //use real database
            ConfigureProductionServices(services);
        }
        public void ConfigureProductionServices(IServiceCollection services)
        {
            // use real database
            // Requires LocalDB which can be installed with SQL Server Express 2016
            // https://www.microsoft.com/en-us/download/details.aspx?id=54284

            services.AddDbContext<AppDBContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("DbConnection")));


            ConfigureServices(services);
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddWebServices(Configuration);

            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IdentityServer.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdentityServer.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
