using MediatR;

namespace ZakupAuta.Application.Listing.Queries.GetAllCarListings
{
    public class GetAllCarListings : IRequest<IEnumerable<ListingDto>>
    {
    }
}