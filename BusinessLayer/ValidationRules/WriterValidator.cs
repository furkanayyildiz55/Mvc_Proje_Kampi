using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş olamaz !");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı boş olamaz !");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar Mail boş olamaz !");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş olamaz !");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmı boş olamaz !");


            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karater giriniz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En fazla 50 karakter girilebilir ");

            RuleFor(X => X.WriterAbout).Matches("A").WithMessage("Hakkında kısmın A harfi geçmelidir");

        }
    }
}
