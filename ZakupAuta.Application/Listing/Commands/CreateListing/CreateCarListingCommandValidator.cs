using FluentValidation;
using ZakupAuta.Application.Listing.Commands.CreateListing;
using ZakupAuta.Domain.Interfaces;

namespace ZakupAuta.Application.Listing.Commands.CreateCarListing

{

    public class CreateCarListingCommandValidator : AbstractValidator<CreateCarListingCommand>
    {
        public CreateCarListingCommandValidator(ICarListingRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nazwa nie może być pusta.")
                .MinimumLength(2).WithMessage("Nazwa musi mieć co najmniej 2 znaki.")
                .MaximumLength(20).WithMessage("Nazwa może mieć maksymalnie 20 znaków.");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Opis nie może być pusty.");

            RuleFor(c => c.Mileage)
                .NotNull().WithMessage("Przebieg nie może być pusty.")
                .LessThan(9999999).WithMessage("Przekroczono maksymalny przebieg.");

            RuleFor(c => c.Price)
                .NotNull().WithMessage("Cena nie może być pusta.")
                .LessThan(9999999).WithMessage("Osiągnięto cenę maksymalną");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Numer telefonu nie może być pusty.")
                .Length(9).WithMessage("Podaj 9-o cyfrowy numer bez żadnych dodatkowych znaków");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("Miasto nie może być puste.")
                .MinimumLength(2).WithMessage("Miasto musi mieć co najmniej 2 znaki.")
                .MaximumLength(30).WithMessage("Miasto może mieć maksymalnie 30 znaków.");

            RuleFor(c => c.Street)
                .MaximumLength(30).WithMessage("Ulica może mieć maksymalnie 30 znaków.");

            RuleFor(c => c.PostalCode)
                .NotEmpty().WithMessage("Kod pocztowy nie może być pusty.");
                
        }
    }
}
