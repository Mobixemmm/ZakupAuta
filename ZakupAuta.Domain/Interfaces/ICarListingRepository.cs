

using ZakupAuta.Domain.Entities;


namespace ZakupAuta.Domain.Interfaces
{
    public interface ICarListingRepository
    {
        Task Commit();
        Task Create(Domain.Entities.Listing carListing);
        Task<IEnumerable<Domain.Entities.Listing>> GetAll();
        Task<Domain.Entities.Listing> GetByEncodedName(string encodedName);
      
    }
}
