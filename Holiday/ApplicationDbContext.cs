
using System;
using Microsoft.EntityFrameworkCore;
using Holiday.Entities;

namespace Holiday
{
    public class ApplicationDbContext : DbContext
    {
        public static string ConnectionString = 
            @"Data Source=172.16.2.164,1433;
            Initial Catalog=QLBepAnDB;
            User Id=sa;Password=123123;
            TrustServerCertificate=True";

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Holiday> Accounts { get; set; }

    }
}

