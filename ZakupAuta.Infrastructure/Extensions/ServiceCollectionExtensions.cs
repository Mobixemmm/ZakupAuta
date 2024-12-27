using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZakupAuta.Application.Listing;
using ZakupAuta.Domain.Interfaces;
using ZakupAuta.Infrastructure.Persistence;
using ZakupAuta.Infrastructure.Repositories;
using ZakupAuta.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using FluentValidation.AspNetCore;
using ZakupAuta.Application.Mappings;
using ZakupAuta.Application.Listing.Commands.CreateCarListing;
using ZakupAuta.Application.ApplicationUser;


namespace ZakupAuta.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            

            services.AddDbContext<ZakupAutaDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("ZakupAuta")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ZakupAutaDbContext>();
                

            services.AddScoped<ZakupAutaSeeder>();

            services.AddScoped<ICarListingRepository, CarListingRepository>();

        }
    }
}
