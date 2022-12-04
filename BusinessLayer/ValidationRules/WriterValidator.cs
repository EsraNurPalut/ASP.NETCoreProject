using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");

            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar mail adresi kısmı boş geçilemez");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Yazar şifre kısmı boş geçilemez");

            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı soyadı kısmı en 2 karakter olmalıdır.");

            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adı soyadı kısmı en fazla 50 karakter olmalıdır.");
        }
    }
}
