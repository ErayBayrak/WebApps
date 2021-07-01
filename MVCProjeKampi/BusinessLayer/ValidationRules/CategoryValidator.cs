using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori ismi boş bırakılamaz.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori ismi 3 karakterden az olamaz.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori ismi 20 karakterden fazla olamaz.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş bırakılamaz.");
        }
    }
}
