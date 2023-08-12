using Domain;
using FluentValidation;

namespace Application.LibrarianWorkplace.Params
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DateAdded).NotEmpty();
            RuleFor(x => x.DateOfChange).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.VendorCode).NotEmpty();
            RuleFor(x => x.YearOfPublishing).NotEmpty();
            RuleFor(x => x.NumberOfCopies).NotEmpty();
            RuleFor(x => x.Exist).NotEmpty();
        }
    }
}