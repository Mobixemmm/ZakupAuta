using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakupAuta.Application.ApplicationUser;
using ZakupAuta.Application.Listing;
using ZakupAuta.Application.Listing.Commands.EditCarListing;
using ZakupAuta.Domain.Entities;


namespace ZakupAuta.Application.Mappings
{
    public class ListingMappingProfile : Profile
    {
        public ListingMappingProfile(IUserContext userContext)
        {

            var user = userContext.GetCurrentUser();

            CreateMap<ListingDto, Domain.Entities.Listing>()
                .ForMember(e => e.ListingDetails, opt => opt.MapFrom(src => new ListingDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,

                }));

            CreateMap<Domain.Entities.Listing, ListingDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null
                                                && (src.CreatedById == user.Id || user.IsInRole("Moderator"))))
                .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ListingDetails.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ListingDetails.City))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ListingDetails.PostalCode))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ListingDetails.PhoneNumber));

            CreateMap<ListingDto, EditCarListingCommand>();

        }
    }
}
