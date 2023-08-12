using Domain;
using FluentValidation;

namespace Application.LibrarianWorkplace.Params
{
    public class ReaderValidator : AbstractValidator<Reader>
    {
        public ReaderValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DateAdded).NotEmpty();
            RuleFor(x => x.DateOfChange).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Exist).NotEmpty();
        }
    }
}