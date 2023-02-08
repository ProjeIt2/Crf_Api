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
  

             
        //public DbSet<KullaniciDto> KullaniciDtoQuery { get; set; }



    }
}
