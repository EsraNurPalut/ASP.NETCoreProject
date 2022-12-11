﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş geçemezsiniz.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog  görselini boş geçemezsiniz.");
            RuleFor(x => x.BlogTitle).MaximumLength(50).WithMessage("Blog başlığı en fazla 50 karakter olmalıdır.");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blog başlığı en az 5 karakter olmalıdır.");
        }
    }
}
