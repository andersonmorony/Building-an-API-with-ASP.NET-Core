using Agend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agend.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PeopleModel> Peoples { get; set; }
        public DbSet<ServiceTypeModel> ServiceTypes { get; set; }
        public DbSet<AgendsModel> Agends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PeopleModel peope = new PeopleModel { Id = 1, Firstname = "Anderson", Lastname = "Ramos" };
            ServiceTypeModel service = new ServiceTypeModel { Id = 1, IsActive = true, Name = "Depilation" };
            modelBuilder.Entity<PeopleModel>().HasData(peope);
            modelBuilder.Entity<ServiceTypeModel>().HasData(service);
            modelBuilder.Entity<AgendsModel>().HasData(new AgendsModel
            {
                Id = 1,
                Day = DateTime.Now,
                PeopleId = peope.Id,
                ServiceTypeId = service.Id
            });

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
