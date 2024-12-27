using Microsoft.Extensions.DependencyInjection;
using ZakupAuta.Application.Listing;
using ZakupAuta.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using ZakupAuta.Application.Listing.Commands.CreateListing;
using MediatR;
using ZakupAuta.Application.Listing.Commands.CreateCarListing;
using ZakupAuta.Application.ApplicationUser;
using AutoMapper;




namespace ZakupAuta.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();

            services.AddMediatR(typeof(CreateCarListingCommand));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new ListingMappingProfile(userContext));
            }).CreateMapper()
           );

            services.AddValidatorsFromAssemblyContaining<CreateCarListingCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
