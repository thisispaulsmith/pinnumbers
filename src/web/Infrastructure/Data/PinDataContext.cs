using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Infrastructure.Data
{
    public class PinDataContext : DbContext
    {
        public PinDataContext(DbContextOptions<PinDataContext> options)
            : base(options)
        {
        }

        public DbSet<PinNumber> PinNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PinNumber>(b =>
            {
                b.HasKey(p => p.Pin);
            });
        }
    }
}
