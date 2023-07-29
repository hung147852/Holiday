
using System;
using Microsoft.EntityFrameworkCore;
using Holiday.Entities;

namespace Holiday
{
    public class ApplicationDbContext : DbContext
    {
        public static string ConnectionString = 
            @"Data Source=10.36.0.36,1433;
            Initial Catalog=TRUNGTV_BEPAN;
            User Id=toannv;Password=@Automation1;
            TrustServerCertificate=True";

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Holiday1> holidays { get; set; }

    }
}

