using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Lütfen alıcı adresini doldurunuz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Lütfen başlık kısmını doldurunuz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Lütfen mesaj kısmını doldurunuz");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen en fazla 3 karakter girişi yapınız");

        }
    }
}
