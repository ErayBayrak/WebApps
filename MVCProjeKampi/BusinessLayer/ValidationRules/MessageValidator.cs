using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş bırakılamaz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş bırakılamaz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj boş bırakılamaz.");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Düzgün bir mail adresi giriniz.");
            RuleFor(x => x.MessageContent).MinimumLength(5).WithMessage("Mesaj içeriği en az 5 karakterden oluşmalıdır.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter girişi yapın.");
        }
    }
}
