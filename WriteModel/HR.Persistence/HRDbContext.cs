using System;
using System.Collections.Generic;
using System.Linq;
using HR.Framework.AssemblyHelper;
using HR.Framework.Core.Persistence;
using HR.Framework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistence
{
    public class HRDbContext : DbContextBase
    {
        public HRDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityMapping = DetectEntityMapping();

            entityMapping.ForEach(a =>
            {
                modelBuilder.ApplyConfiguration(a);

            });
        }


        protected List<dynamic> DetectEntityMapping()
        {

            var assemblyHelper = new AssemblyDiscovery("HR*.dll");
            var getType = assemblyHelper.DiscoverTypes<IEntityMapping>("HR")
                .Select(Activator.CreateInstance)
                .Cast<dynamic>()
                .ToList();

            return getType;
        }
    }
}
