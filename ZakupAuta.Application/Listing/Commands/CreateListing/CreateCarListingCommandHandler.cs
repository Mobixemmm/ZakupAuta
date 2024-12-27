using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakupAuta.Domain.Interfaces;
using ZakupAuta.Application.ApplicationUser;

namespace ZakupAuta.Application.Listing.Commands.CreateListing
{
    public class CreateCarListingCommandHandler : IRequestHandler<CreateCarListingCommand>
    {
        private readonly ICarListingRepository _carListingRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateCarListingCommandHandler(ICarListingRepository carListingRepository, IMapper mapper, IUserContext userContext)
        {
            _carListingRepository = carListingRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateCarListingCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
           

            var carListing = _mapper.Map<Domain.Entities.Listing>(request);
            carListing.EncodeName();

            carListing.CreatedById = currentUser.Id;

            await _carListingRepository.Create(carListing);

            return Unit.Value;
        }
    }
}
