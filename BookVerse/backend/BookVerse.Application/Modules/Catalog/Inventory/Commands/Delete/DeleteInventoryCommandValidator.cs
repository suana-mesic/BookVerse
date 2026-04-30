namespace BookVerse.Application.Modules.Catalog.Inventory.Commands.Delete
{
    public class DeleteInventoryCommandValidator : AbstractValidator<DeleteInventoryCommand>
    {
        public DeleteInventoryCommandValidator()
        {
            RuleFor(x => x.BookId).GreaterThan(0).WithMessage("BookId must not be zero.");
            RuleFor(x => x.StoreId).GreaterThan(0).WithMessage("StoreId must not be zero.");
        }
    }
}
