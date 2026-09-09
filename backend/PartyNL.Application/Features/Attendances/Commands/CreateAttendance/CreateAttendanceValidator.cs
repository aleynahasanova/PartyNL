using FluentValidation;

namespace PartyNL.Application.Features.Attendances.Commands.CreateAttendance;

public sealed class CreateAttendanceValidator : AbstractValidator<CreateAttendanceCommand>
{
    public CreateAttendanceValidator()
    {
        RuleFor(command => command.UserId).NotEmpty();
        RuleFor(command => command.EventId).NotEmpty();
        RuleFor(command => command.Status).IsInEnum();
        RuleFor(command => command.JoinedAt).NotEmpty();
    }
}