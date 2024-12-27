using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ZakupAuta.Application.Listing.Commands.EditCarListing
{
    public class EditCarListingCommandValidator : AbstractValidator<EditCarListingCommand>
    {
        public EditCarListingCommandValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Podaj opis");
            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Numer telefonu nie może być pusty")
                .Length(9);
        }
    }
}