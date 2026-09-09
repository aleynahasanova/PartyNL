using FluentValidation;

namespace PartyNL.Application.Features.Favorites.Commands.UpdateFavorite;

public sealed class UpdateFavoriteValidator : AbstractValidator<UpdateFavoriteCommand>
{
    public UpdateFavoriteValidator()
    {
        RuleFor(command => command.UserId).NotEmpty();
        RuleFor(command => command.EventId).NotEmpty();
        RuleFor(command => command.CreatedAt).NotEmpty();
    }
}