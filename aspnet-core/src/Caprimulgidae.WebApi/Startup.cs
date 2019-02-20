using Antilopes.WebApi.Extension;
using Caprimulgidae.Application.AutoMapper;
using Caprimulgidae.Infra.CrossCutting.IoC;
using Caprimulgidae.WebApi.Models.Info;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Caprimulgidae.WebApi
{
    public class Startup
    {
        const string AssemblyRefToMediatR = "Caprimulgidae.Domain";
        public IConfiguration Configuration { get; }
        public ApiInfo ApiInfo = new ApiInfo();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            configuration.Bind("ApiInfo", ApiInfo);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCustonWebApi(ApiInfo);
            services.AddAutoMapperSetup(cfg => AutoMapperConfig.RegisterMappings(cfg));
            services.AddCustonSwaggerGen(ApiInfo);
            services.AddMediatRSetup(AssemblyRefToMediatR);
            services.RegisterServices(Configuration);
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseCustonAddSwaggerGen(ApiInfo);
        }
    }
}
