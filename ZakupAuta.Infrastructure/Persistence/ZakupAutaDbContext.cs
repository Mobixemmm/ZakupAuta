using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZakupAuta.Domain.Entities;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ZakupAuta.Infrastructure.Persistence
{
    public class ZakupAutaDbContext : IdentityDbContext
    {
        public ZakupAutaDbContext(DbContextOptions<ZakupAutaDbContext> options) : base(options) { }
        public DbSet<Listing> Listings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Listing>()
                .OwnsOne(l => l.ListingDetails); // Konfiguracja relacji typu "owned"
        }

    }
}
