using AutoMapper;
using ZakupAuta.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakupAuta.Application.Listing.Queries.GetCarListingByEncodedName
{
    public class GetListingByEncodedNameQueryHandler : IRequestHandler<GetCarListingByEncodedNameQuery, ListingDto>
    {
        private readonly ICarListingRepository _carListingRepository;
        private readonly IMapper _mapper;

        public GetListingByEncodedNameQueryHandler(ICarListingRepository carListingRepository, IMapper mapper)
        {
            _carListingRepository = carListingRepository;
            _mapper = mapper;
        }
        public async Task<ListingDto> Handle(GetCarListingByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var carListing = await _carListingRepository.GetByEncodedName(request.EncodedName);

            var dto = _mapper.Map<ListingDto>(carListing);

            return dto;
        }
    }
}