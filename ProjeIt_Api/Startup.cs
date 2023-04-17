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
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjeIt_Api", Version = "v1" });
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjeIt_Api", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
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
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<ISocialLifeRepository, SocialLifeRepository>();
            services.AddScoped<ISocialLifeService, SocialLifeService>();
            services.AddScoped<IEnvironmentalExposureRepository, EnvironmentalExposureRepository>();
            services.AddScoped<IEnvironmentalExposureService, EnvironmentalExposureService>();
            services.AddScoped<IDiseaseRepository, DiseaseRepository>();
            services.AddScoped<IDiseaseService, DiseaseService>();
            services.AddScoped<IDiagnosisHistoryRepository, DiagnosisHistoryRepository>();
            services.AddScoped<IDiagnosisHistoryService, DiagnosisHistoryService>();
            services.AddScoped<IMedicalStatusRepository, MedicalStatusRepository>();
            services.AddScoped<IMedicalStatusService, MedicalStatusService>();
            services.AddScoped<IICD10CodeRepository, ICD10CodeRepository>();
            services.AddScoped<IICD10CodeService, ICD10CodeService>();
            services.AddScoped<IDonorMedicalHistoryRepository, DonorMedicalHistoryRepository>();
            services.AddScoped<IDonorMedicalHistoryService, DonorMedicalHistoryService>();
            services.AddScoped<IAffinityRepository, AffinityRepository>();
            services.AddScoped<IAffinityService, AffinityService>();
            services.AddScoped<IFamilyMedicalHistoryRepository, FamilyMedicalHistoryRepository>();
            services.AddScoped<IFamilyMedicalHistoryService, FamilyMedicalHistoryService>();
            services.AddScoped<IDiagnosisRepository, DiagnosisRepository>();
            services.AddScoped<IDiagnosisService, DiagnosisService>();
            services.AddScoped<IGynecologicalHistoryRepository, GynecologicalHistoryRepository>();
            services.AddScoped<IGynecologicalHistoryService, GynecologicalHistoryService>();
            services.AddScoped<IPillRepository, PillRepository>();
            services.AddScoped<IPillService, PillService>();
            services.AddScoped<IUsageRepository, UsageRepository>();
            services.AddScoped<IUsageService, UsageService>();
            services.AddScoped<ICurrentStatusRepository, CurrentStatusRepository>();
            services.AddScoped<ICurrentStatusService, CurrentStatusService>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IVirusRepository, VirusRepository>();
            services.AddScoped<IVirusService, VirusService>();
            services.AddScoped<IViralInfectionRepository, ViralInfectionRepository>();
            services.AddScoped<IViralInfectionService, ViralInfectionService>();
            services.AddScoped<IOperationProcedureRepository, OperationProcedureRepository>();
            services.AddScoped<IOperationProcedureService, OperationProcedureService>();
            services.AddScoped<IAnatomicalAreaRepository, AnatomicalAreaRepository>();
            services.AddScoped<IAnatomicalAreaService, AnatomicalAreaService>();
            services.AddScoped<IAdditionTypeRepository, AdditionTypeRepository>();
            services.AddScoped<IAdditionTypeService, AdditionTypeService>();
            services.AddScoped<ISpecimenRepository, SpecimenRepository>();
            services.AddScoped<ISpecimenService, SpecimenService>();
            services.AddScoped<IDiagnosisInformationRepository, DiagnosisInformationRepository>();
            services.AddScoped<IDiagnosisInformationService, DiagnosisInformationService>();
            services.AddScoped<ITumorAreaRepository, TumorAreaRepository>();
            services.AddScoped<ITumorAreaService, TumorAreaService>();
            services.AddScoped<ITNMRepository, TNMRepository>();
            services.AddScoped<ITNMService, TNMService>();
            services.AddScoped<ITumorTypeRepository, TumorTypeRepository>();
            services.AddScoped<ITumorTypeService, TumorTypeService>();
            services.AddScoped<IPhaseRepository, PhaseRepository>();
            services.AddScoped<IPhaseService, PhaseService>();
            services.AddScoped<ITumorStatusRepository, TumorStatusRepository>();
            services.AddScoped<ITumorStatusService, TumorStatusService>();
            services.AddScoped<IDoctorRequestedReportRepository, DoctorRequestedReportRepository>();
            services.AddScoped<IDoctorRequestedReportService, DoctorRequestedReportService>();
            services.AddScoped<IClinicalStatusRepository, ClinicalStatusRepository>();
            services.AddScoped<IClinicalStatusService, ClinicalStatusService>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IMetastasisRepository, MetastasisRepository>();
            services.AddScoped<IMetastasisService, MetastasisService>();
            services.AddScoped<ILymphNodeRepository, LymphNodeRepository>();
            services.AddScoped<ILymphNodeService, LymphNodeService>();
            services.AddScoped<IDistantMetastasisRepository, DistantMetastasisRepository>();
            services.AddScoped<IDistantMetastasisService, DistantMetastasisService>();
            services.AddScoped<IMetastasisStatusRepository, MetastasisStatusRepository>();
            services.AddScoped<IMetastasisStatusService, MetastasisStatusService>();
            services.AddScoped<ITreatmentRepository, TreatmentRepository>();
            services.AddScoped<ITreatmentService, TreatmentService>();
            services.AddScoped<ICancerTreatmentRepository, CancerTreatmentRepository>();
            services.AddScoped<ICancerTreatmentService, CancerTreatmentService>();
            services.AddScoped<IUploadFileRepository, UploadFileRepository>();
            services.AddScoped<IUploadFileService, UploadFileService>();
             services.AddScoped<IUploadFilesPatientICFRepository, UploadFilesPatientICFRepository>();
            services.AddScoped<IUploadFilesPatientICFService, UploadFilesPatientICFService>();
            services.AddScoped<IAdditionalInformationRepository, AdditionalInformationRepository>();
            services.AddScoped<IAdditionalInformationService, AdditionalInformationService>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IDailyRepository, DailyRepository>();
            services.AddScoped<IDailyService, DailyService>();
            services.AddScoped<IBranchNameRepository, BranchNameRepository>();
            services.AddScoped<IBranchNameService, BranchNameService>();
            services.AddScoped<ITaskUploadFileRepository, TaskUploadFileRepository>();
            services.AddScoped<ITaskUploadFileService, TaskUploadFileService>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{  }
            app.UseDeveloperExceptionPage();
            app.UseSwagger();

            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjeIt_Api v1"));
            app.UseSwaggerUI(c =>{ c.SwaggerEndpoint("./v1/swagger.json", "My API V1"); //originally "./swagger/v1/swagger.json"
            });

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
