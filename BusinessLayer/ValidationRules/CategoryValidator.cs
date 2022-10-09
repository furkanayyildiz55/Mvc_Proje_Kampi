using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FloentValidation
{

    //Validasyon işlemleri için AbstractValidator sınıfnın özelliklerini kullanıcaz 
    //AbstractValidator validate işlemlerini gerçekleştireceğimiz sınıfı veriyoruz
    //kurallarımızı constructor a yazıyoruz
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş olamaz !");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama boş olamaz !");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karater giriniz");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("En fazla 20 karakter girilebilir ");
            
        }
    }
}
