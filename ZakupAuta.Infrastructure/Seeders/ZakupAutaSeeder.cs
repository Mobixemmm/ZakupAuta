using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakupAuta.Infrastructure.Persistence;

namespace ZakupAuta.Infrastructure.Seeders
{
    public class ZakupAutaSeeder
    {
        private readonly ZakupAutaDbContext _dbContext;
        public ZakupAutaSeeder(ZakupAutaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Listings.Any())
                {
                    var Mazda = new Domain.Entities.Listing()
                    {
                        Name = "Mazda 5",
                        Description = "Troche rdzewieje, ale technicznie jest idealna",
                        Price = 12500,
                        Mileage = 275000,
                        ListingDetails = new()
                        {
                            City = "Poznań",
                            Street = "Półwiejska 69",
                            PostalCode = "61-870",
                            PhoneNumber = "+48660383071"
                        }

                    };

                    Mazda.EncodeName();

                    _dbContext.Listings.Add(Mazda);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
