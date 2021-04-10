using IdentityServer.Web.Configurations;
using IdentityServer.Web.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace IdentityServer.Web
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

            var baseUrlConfig = new BaseUrlConfiguration();
            Configuration.Bind(BaseUrlConfiguration.CONFIG_NAME, baseUrlConfig);

            GlobalConstants.ApiBase = baseUrlConfig.ApiBase;
            GlobalConstants.IdentityServerBase = baseUrlConfig.IdentityServerBase;

            services.AddWebServices(Configuration);

            services.AddControllersWithViews();

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = "https://localhost:5001";
                options.GetClaimsFromUserInfoEndpoint = true;
                options.ClientId = "mvc";
                options.ClientSecret = "secret";
                options.ResponseType = "code";

                options.GetClaimsFromUserInfoEndpoint = true;
                options.ClaimActions.MapJsonKey("role", "role", "role");
                options.TokenValidationParameters.NameClaimType = "role";
                options.TokenValidationParameters.RoleClaimType = "role";

                options.Scope.Add("api1");
                options.SaveTokens = true;
            });


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
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute()
                    .RequireAuthorization();
            });
        }
    }
}
