using ZakupAuta.Domain.Entities;
using ZakupAuta.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakupAuta.Application.Listing.Commands.EditCarListing;
using ZakupAuta.Application.ApplicationUser;
namespace ZakupAuta.Application.Listing.Commands.EditListing
{
    internal class EditCarListingCommandHandler : IRequestHandler<EditCarListingCommand>
    {
        private readonly ICarListingRepository _repository;
        private readonly IUserContext _userContext;
        public EditCarListingCommandHandler(ICarListingRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditCarListingCommand request, CancellationToken cancellationToken)
        {
            var carListing = await _repository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEdibable = user != null && (carListing.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEdibable)
            {
                return Unit.Value;
            }

            carListing.Description = request.Description;
            carListing.Price = request.Price;
            carListing.ListingDetails.City = request.City;
            carListing.ListingDetails.PhoneNumber = request.PhoneNumber;
            carListing.ListingDetails.PostalCode = request.PostalCode;
            carListing.ListingDetails.Street = request.Street;
            await _repository.Commit();
            return Unit.Value;
        }
    }
}