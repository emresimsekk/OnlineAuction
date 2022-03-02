using FluentValidation;

namespace OnlineAuctionApplication.Commands.OrderCreate
{
    public class OrderCreateValidator : AbstractValidator<OrderCreateCommand>
    {
        public OrderCreateValidator()
        {
            RuleFor(v => v.SellerUserName)
                .EmailAddress()
                .NotEmpty();

            RuleFor(v => v.ProductId)
                .NotEmpty();
        }
    }
}
