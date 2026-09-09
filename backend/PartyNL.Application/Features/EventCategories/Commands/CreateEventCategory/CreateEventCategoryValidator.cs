using FluentValidation;

namespace PartyNL.Application.Features.EventCategories.Commands.CreateEventCategory;

public sealed class CreateEventCategoryValidator : AbstractValidator<CreateEventCategoryCommand>
{
    public CreateEventCategoryValidator()
    {
        RuleFor(command => command.EventId).NotEmpty();
        RuleFor(command => command.CategoryId).NotEmpty();
    }
}