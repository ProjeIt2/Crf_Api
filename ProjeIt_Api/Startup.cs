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
  

            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddScoped<IPersonnelRepository, PersonnelRepository>();
            services.AddScoped<IPersonnelService, PersonnelService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IProjectInformationRepository, ProjectInformationRepository>();
            services.AddScoped<IProjectInformationService, ProjectInformationService>();
            services.AddScoped<IClinicalDiagnosisRepository, ClinicalDiagnosisRepository>();
            services.AddScoped<IClinicalDiagnosisService, ClinicalDiagnosisService>();
            services.AddScoped<IPatientInformationRepository, PatientInformationRepository>();
            services.AddScoped<IPatientInformationService, PatientInformationService>();
              services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{  }
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjeIt_Api v1"));
          
      
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
