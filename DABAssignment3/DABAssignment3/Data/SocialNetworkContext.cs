using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WeatherDataAPI.Models;

namespace WeatherDataAPI.Data
{
    public class WeatherDataContext : IdentityDbContext // : DbContext
    {
        public WeatherDataContext(DbContextOptions<WeatherDataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Dummy data
        }

        public DbSet<WeatherData> WeatherDatas { get; set; }
    }
}