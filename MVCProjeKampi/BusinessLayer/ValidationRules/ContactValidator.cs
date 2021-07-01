using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Kısmını Boş Geçemezsiniz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Kısmını Boş Geçemezsiniz.");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Kısmını Boş Geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Kısmını Boş Geçemezsiniz.");
            RuleFor(x => x.Message).MinimumLength(3).WithMessage("Mesaj Kısmı En Az 3 Karakterden Oluşmalıdır.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu Kısmı En Az 3 Karakterden Oluşmalıdır.");
            RuleFor(x => x.Message).MaximumLength(20).WithMessage("Mesaj Kısmı En Az 3 Karakterden Oluşmalıdır.");
        }
    }
}
