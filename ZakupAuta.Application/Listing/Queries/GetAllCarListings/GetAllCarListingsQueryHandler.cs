using AutoMapper;
using ZakupAuta.Domain.Interfaces;
using MediatR;

namespace ZakupAuta.Application.Listing.Queries.GetAllCarListings
{
    internal class GetAllCarListingsQueryHandler : IRequestHandler<GetAllCarListings, IEnumerable<ListingDto>>
    {
        private readonly ICarListingRepository _carListingRepository;
        private readonly IMapper _mapper;

        public GetAllCarListingsQueryHandler(ICarListingRepository carListingRepository, IMapper mapper)
        {
            _carListingRepository = carListingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListingDto>> Handle(GetAllCarListings request, CancellationToken cancellationToken)
        {
            var carListings = await _carListingRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ListingDto>>(carListings);


            return dtos;
        }
    }
}