using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WeatherApi.Models;

namespace WeatherApi.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

}
