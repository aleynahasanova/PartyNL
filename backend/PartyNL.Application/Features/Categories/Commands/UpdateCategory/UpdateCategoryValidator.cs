using FluentValidation;

namespace PartyNL.Application.Features.Categories.Commands.UpdateCategory;

public sealed class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
        RuleFor(command => command.Name).NotEmpty().MaximumLength(100);
        RuleFor(command => command.Icon).MaximumLength(200).When(command => command.Icon is not null);
    }
}