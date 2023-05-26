using FluentValidation;
using WebAuth.Client.Models.Login;

namespace WebAuth.Client.Services;

public class TokenValidator : AbstractValidator<UserToken>
{
    private readonly IDateTimeService _dateTimeService;
    public TokenValidator(IDateTimeService dateTimeService)
    {
        _dateTimeService = dateTimeService;

        RuleFor(token => token.Token).NotNull();
        RuleFor(token => token.Token).NotEmpty();

        RuleFor(token => token.Expiration).GreaterThan(_dateTimeService.GetDateTimeNow());
    }
    protected bool BeGreaterThanNow(DateTime dateTime)
    {
        return dateTime > _dateTimeService.GetDateTimeNow();
    }
}