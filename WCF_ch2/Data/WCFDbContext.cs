using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using WCF_ch2.Models;

namespace WCF_ch2.Data
{
    public class WCFDbContext : DbContext
    {
        //public WCFDbContext(DbContextOptions<WCFDbContext> options) : base(options)
        //{
        //}

        public DbSet<UserModel> UserModel { get; set; } = null;

        public WCFDbContext()
        {
            try
            {
                Database.EnsureCreated();
            }
            catch
            {

            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");

            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Wcf;Username=postgres;Password=123");
        }
    }
}