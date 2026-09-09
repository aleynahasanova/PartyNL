using FluentValidation;

namespace PartyNL.Application.Features.Attendances.Commands.UpdateAttendance;

public sealed class UpdateAttendanceValidator : AbstractValidator<UpdateAttendanceCommand>
{
    public UpdateAttendanceValidator()
    {
        RuleFor(command => command.UserId).NotEmpty();
        RuleFor(command => command.EventId).NotEmpty();
        RuleFor(command => command.Status).IsInEnum();
        RuleFor(command => command.JoinedAt).NotEmpty();
    }
}