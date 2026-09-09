using FluentValidation;

namespace PartyNL.Application.Features.Categories.Commands.CreateCategory;

public sealed class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(command => command.Name).NotEmpty().MaximumLength(100);
        RuleFor(command => command.Icon).MaximumLength(200).When(command => command.Icon is not null);
    }
}