﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TekGain.DAL.Entities;
using System;
using Microsoft.EntityFrameworkCore.Design;

namespace TekGain.DAL
{
    public class TekGainContext : IdentityDbContext<User>
    {
        public TekGainContext()
        {
        }

        public TekGainContext(DbContextOptions<TekGainContext> options) : base(options)
        {


        }

        // Implement the DbSet properties here

        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Associate> Associates { get; set; }
        public DbSet<Course> Courses { get; set; }

        public void GetCourses()
        {
            throw new NotImplementedException();
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TekGainContext>
    {
        public TekGainContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../TekGain.DAL/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<TekGainContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new TekGainContext(builder.Options);
        }
    }
}