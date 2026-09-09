using FluentValidation;

namespace PartyNL.Application.Features.Favorites.Commands.CreateFavorite;

public sealed class CreateFavoriteValidator : AbstractValidator<CreateFavoriteCommand>
{
    public CreateFavoriteValidator()
    {
        RuleFor(command => command.UserId).NotEmpty();
        RuleFor(command => command.EventId).NotEmpty();
        RuleFor(command => command.CreatedAt).NotEmpty();
    }
}