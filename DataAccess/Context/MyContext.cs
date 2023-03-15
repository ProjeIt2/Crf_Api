using Entities;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class ProjeItContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=94.73.170.34;Initial Catalog=u0993226_dbD8A;uid=u0993226_userD8A;pwd=Crf.Digital134!!;Integrated Security=false;MultipleActiveResultSets=True;");
        }





        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<ProjectInformation> ProjectInformations { get; set; }
        public DbSet<ClinicalDiagnosis> ClinicalDiagnosis { get; set; }
        public DbSet<PatientInformation> PatientInformations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<SocialLife> SocialLives { get; set; }
        public DbSet<EnvironmentalExposure> EnvironmentalExposures { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<DiagnosisHistory> DiagnosisHistories { get; set; }
        public DbSet<MedicalStatus> MedicalStatus { get; set; }
        public DbSet<ICD10Code> ICD10Code { get; set; }
        public DbSet<DonorMedicalHistory> DonorMedicalHistories { get; set; }
        public DbSet<Affinity> Affinities { get; set; }
        public DbSet<FamilyMedicalHistory> FamilyMedicalHistories { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<GynecologicalHistory> GynecologicalHistories { get; set; }
        public DbSet<Pill> Pills { get; set; }
        public DbSet<Usage> Usages { get; set; }
        public DbSet<CurrentStatus> CurrentStatus { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Virus> Virus { get; set; }
        public DbSet<ViralInfection> ViralInfections { get; set; }
        public DbSet<OperationProcedure> OperationProcedures { get; set; }
        public DbSet<AnatomicalArea> AnatomicalAreas { get; set; }
        public DbSet<AdditionType> AdditionTypes { get; set; }
        public DbSet<Specimen> Specimen { get; set; }
        public DbSet<DiagnosisInformation> DiagnosisInformations { get; set; }
        public DbSet<TumorArea> TumorAreas { get; set; }
        public DbSet<TNM> TNMs { get; set; }
        public DbSet<TumorType> TumorTypes { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<TumorStatus> TumorStatus { get; set; }
        public DbSet<DoctorRequestedReport> DoctorRequestedReports { get; set; }
        public DbSet<ClinicalStatus> ClinicalStatus { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Metastasis> Metastasises { get; set; }
        public DbSet<LymphNode> LymphNodes { get; set; }
        public DbSet<DistantMetastasis> DistantMetastases { get; set; }
        public DbSet<MetastasisStatus> MetastasisStatus { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<CancerTreatment> CancerTreatments { get; set; }
        public DbSet<UploadFile> UploadFiles { get; set; }
        public DbSet<UploadFilesPatientICF> UploadFilesPatientICFs { get; set; }
        public DbSet<AdditionalInformation> AdditionalInformations { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }

        //public DbSet<FormListVM> FormVMQuery { get; set; }

    }
}
