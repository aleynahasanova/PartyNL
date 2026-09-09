using FluentValidation;

namespace PartyNL.Application.Features.Events.Commands.CreateEvent;

public sealed class CreateEventValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventValidator()
    {
        RuleFor(command => command.OrganizerId).NotEmpty();
        RuleFor(command => command.LocationId).NotEmpty();
        RuleFor(command => command.Title).NotEmpty().MaximumLength(200);
        RuleFor(command => command.Description).MaximumLength(4000).When(command => command.Description is not null);
        RuleFor(command => command.EndDate).GreaterThan(command => command.StartDate);
        RuleFor(command => command.Price).GreaterThanOrEqualTo(0);
        RuleFor(command => command.Capacity).GreaterThan(0);
        RuleFor(command => command.MinimumAge).GreaterThanOrEqualTo(0);
        RuleFor(command => command.Visibility).IsInEnum();
        RuleFor(command => command.Status).IsInEnum();
        RuleFor(command => command.CoverImageUrl).MaximumLength(500).When(command => command.CoverImageUrl is not null);
    }
}