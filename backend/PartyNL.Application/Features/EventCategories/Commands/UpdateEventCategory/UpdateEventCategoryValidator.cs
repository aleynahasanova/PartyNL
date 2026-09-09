using FluentValidation;

namespace PartyNL.Application.Features.EventCategories.Commands.UpdateEventCategory;

public sealed class UpdateEventCategoryValidator : AbstractValidator<UpdateEventCategoryCommand>
{
    public UpdateEventCategoryValidator()
    {
        RuleFor(command => command.EventId).NotEmpty();
        RuleFor(command => command.CategoryId).NotEmpty();
    }
}