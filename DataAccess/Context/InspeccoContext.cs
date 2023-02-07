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
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=DESKTOP-639F8SA\SQLEXPRESS;Initial Catalog=ProjeIt;Integrated Security=True");
        }


        public DbSet<HastaUzmanlik> HastaUzmanlik { get; set; }
        public DbSet<KanserTur> KanserTurleri { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<MateryalTip> MateryalTipleri { get; set; }
        public DbSet<ProjeTanim> ProjeTanimlari { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Sponsor> Sponsor { get; set; }
        public DbSet<TüpCins> TüpCinsleri { get; set; }







        public DbSet<ProjeTanimDto> ProjeTanimDtoQuery { get; set; }
        public DbSet<KullaniciDto> KullaniciDtoQuery { get; set; }



    }
}
