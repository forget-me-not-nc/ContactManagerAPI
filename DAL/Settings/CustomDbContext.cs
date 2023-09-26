using DAL.Entities;
using DAL.Entities.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Settings
{
    public class CustomDbContext: DbContext
    {
        public DbSet<ContactInfo> Infos { get; set; }

        public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContactInfoConfig());
        }
    }
}
