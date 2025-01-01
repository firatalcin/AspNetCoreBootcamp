using FluentValidation;
using ToDoAppNTier.Dtos.WorkDtos;

namespace ToDoAppNTier.Business.ValidationRules
{
    public class WorkUpdateDtoValidator : AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definition is required");
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
