using FluentValidation;

namespace PartyNL.Application.Features.Organizers.Commands.CreateOrganizer;

public sealed class CreateOrganizerValidator : AbstractValidator<CreateOrganizerCommand>
{
    public CreateOrganizerValidator()
    {
        RuleFor(command => command.Name).NotEmpty().MaximumLength(200);
        RuleFor(command => command.Description).MaximumLength(2000).When(command => command.Description is not null);
        RuleFor(command => command.Email).EmailAddress().MaximumLength(320).When(command => !string.IsNullOrWhiteSpace(command.Email));
        RuleFor(command => command.Phone).MaximumLength(50).When(command => command.Phone is not null);
        RuleFor(command => command.Website).MaximumLength(500).When(command => command.Website is not null);
        RuleFor(command => command.LogoUrl).MaximumLength(500).When(command => command.LogoUrl is not null);
    }
}