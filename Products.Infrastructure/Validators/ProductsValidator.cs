using FluentValidation;
using Products.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure.Validators
{
    public class ProductsValidator : AbstractValidator<ProductDto>
    {
        public ProductsValidator()
        {
            RuleFor(product => product.Name)
                .NotNull()
                .NotEmpty()
                .Length(3, 50);

            RuleFor(product => product.Description)
                .NotNull()
                .Length(10, 500);

            RuleFor(product => product.CategoryId)
                .NotNull()
                .NotEmpty();

            RuleFor(product => product.Price)
                .NotNull()
                .NotEmpty()
                .GreaterThan(10000);

            RuleFor(product => product.PurchaseDate)
                .LessThan(DateTime.Now);

            RuleFor(product => product.Active)
                .NotNull()
                .NotEmpty();
        }
    }
}
