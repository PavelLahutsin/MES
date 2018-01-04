﻿using System.Data.Entity;
using MES.DAL.Entities;
using MES.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MES.DAL.EF
{
    public class MesContext : IdentityDbContext<ApplicationUser>, IMesContext
    {
        public DbSet<Detail> Details { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ArrivalOfDetail> ArrivalOfDetails { get; set; }
        public DbSet<DefectDetail> DefectDetails { get; set; }
        public DbSet<StructureOfTheProduct> StructureOfTheProducts { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<GroupProduct> GroupProducts { get; set; }


        static MesContext()
        {
            Database.SetInitializer<MesContext>(new MesDbInitializer());
        }
        public MesContext()
            : base("MesContextDb")
        {
        }
    }
}
