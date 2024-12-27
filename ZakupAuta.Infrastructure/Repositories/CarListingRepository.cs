
using Microsoft.EntityFrameworkCore;
using ZakupAuta.Domain.Interfaces;
using ZakupAuta.Infrastructure.Persistence;
using ZakupAuta.Application.Listing.Queries;

namespace ZakupAuta.Infrastructure.Repositories
{
    internal class CarListingRepository : ICarListingRepository
    {
        private readonly ZakupAutaDbContext _dbContext;

        public CarListingRepository(ZakupAutaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Commit()
         => _dbContext.SaveChangesAsync();
        public async Task Create(Domain.Entities.Listing carListing)
        {
            _dbContext.Add(carListing);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Domain.Entities.Listing>> GetAll()
         => await _dbContext.Listings.ToListAsync();
        public async Task<Domain.Entities.Listing> GetByEncodedName(string encodedName)
        => await _dbContext.Listings.FirstAsync(c => c.EncodedName == encodedName);



    }
}
