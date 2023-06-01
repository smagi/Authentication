using FluentValidation;
using FluentValidation.Results;
using WebAuth.Client.Models.Login;

namespace WebAuth.Client.Services;

public class TokenValidator : AbstractValidator<UserToken>
{
    private readonly IDateTimeService _dateTimeService;
    public TokenValidator(IDateTimeService dateTimeService)
    {
        _dateTimeService = dateTimeService;

        RuleFor(token => token).NotNull();

        RuleFor(token => token.Token).NotNull();
        RuleFor(token => token.Token).NotEmpty();

        RuleFor(token => token.Expiration).Must(BeGreaterThanNow);
    }
    public override ValidationResult Validate(ValidationContext<UserToken> context)
    {
        return (context.InstanceToValidate == null) 
            ? new ValidationResult(new[] { new ValidationFailure("Property", $"{nameof(UserToken)} is null") })
            : base.Validate(context);       
    }
    protected bool BeGreaterThanNow(DateTime dateTime)
    {
        return dateTime > _dateTimeService.GetDateTimeNow();
    }
}