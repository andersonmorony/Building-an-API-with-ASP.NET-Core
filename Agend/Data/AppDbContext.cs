﻿using Agend.Models;
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
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
