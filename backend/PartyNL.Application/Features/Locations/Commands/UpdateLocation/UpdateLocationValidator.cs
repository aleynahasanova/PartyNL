using FluentValidation;

namespace PartyNL.Application.Features.Locations.Commands.UpdateLocation;

public sealed class UpdateLocationValidator : AbstractValidator<UpdateLocationCommand>
{
    public UpdateLocationValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
        RuleFor(command => command.Name).MaximumLength(200).When(command => command.Name is not null);
        RuleFor(command => command.Street).MaximumLength(200).When(command => command.Street is not null);
        RuleFor(command => command.City).MaximumLength(100).When(command => command.City is not null);
        RuleFor(command => command.PostalCode).MaximumLength(20).When(command => command.PostalCode is not null);
        RuleFor(command => command.Province).MaximumLength(100).When(command => command.Province is not null);
        RuleFor(command => command.Country).MaximumLength(100).When(command => command.Country is not null);
        RuleFor(command => command.Latitude).InclusiveBetween(-90, 90);
        RuleFor(command => command.Longitude).InclusiveBetween(-180, 180);
    }
}