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
                 optionsBuilder.UseSqlServer(connectionString: @"Data Source=94.73.170.45;Initial Catalog=u9916590_db588;uid=u9916590_user588;pwd=Crf.Digital134!!;Integrated Security=false;MultipleActiveResultSets=True;");
        }

             
        public DbSet<AppUser> AppUsers { get; set; }
  

             
        //public DbSet<KullaniciDto> KullaniciDtoQuery { get; set; }



    }
}
