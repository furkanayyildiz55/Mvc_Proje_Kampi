using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {

        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresi boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adı boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı Adresi boş geçilemez");

            RuleFor(f => f.Subject).MinimumLength(5).MaximumLength(50).WithMessage("En az 5 -- En fazla 50 karakter girebilirsiniz");
            
        
        }


    }
}
