using Business.Services;
using Business.Services.Interfeces;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeIt_Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjeIt_Api", Version = "v1" });
            });
            #region ServiceAndRepository
            services.AddScoped<IHastaUzmanlikRepository, HastaUzmanlikRepository>();
            services.AddScoped<IHastaUzmanlikService, HastaUzmanlikService>();

            services.AddScoped<IKanserTurRepository, KanserTurRepository>();
            services.AddScoped<IKanserTurService, KanserTurService>();

            services.AddScoped<IMateryalTipRepository, MateryalTipRepository>();
            services.AddScoped<IMateryalTipService, MateryalTipService>();

            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IRolService, RolService>();

            services.AddScoped<ISponsorRepository, SponsorRepository>();
            services.AddScoped<ISponsorService, SponsorService>();

            services.AddScoped<ITüpCinsRepository, TüpCinsRepository>();
            services.AddScoped<ITüpCinsService, TüpCinsService>();

            services.AddScoped<IKullaniciRepository, KullaniciRepository>();
            services.AddScoped<IKullaniciService, KullaniciService>();

            services.AddScoped<IProjeTanimRepository, ProjeTanimRepository>();
            services.AddScoped<IProjeTanimService, ProjeTanimService>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjeIt_Api v1"));
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
