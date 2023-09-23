using EasyCash.DTOLayer.DTOS.AppUserDTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.BusinessLayer.ValidationRules.AppUserValidator
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez!");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı alanı boş geçilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Posta alanı boş geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrar alanı boş geçilemez!");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Ad alanı maks 30 karakterden oluşmalıdır!");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Ad alanı en az 2 karakterden oluşmalıdır!");
            RuleFor(x => x.ConfirmPassword).Equal(z => z.Password).WithMessage("Parolanız eşleşmiyor!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir E-posta adresi giriniz!");



        }
    }
}
