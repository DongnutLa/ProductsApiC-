using FluentValidation;
using Products.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure.Validators
{
    public class CategoriesValidator : AbstractValidator<CategoryDto>
    {
        public CategoriesValidator()
        {
            RuleFor(category => category.Name)
                .NotNull()
                .NotEmpty()
                .Length(3, 50);
        }
    }
}
