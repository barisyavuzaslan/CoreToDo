using CoreProject.ToDo.DTO.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.ValidationRules.FluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kulanıcı adı boş geçilemez");
            RuleFor(I => I.Password).NotNull().WithMessage("Parola alanı boş geçilemez");
            RuleFor(I => I.ConfirmPassword).NotNull().WithMessage("Parola onay alanı geçilemez");
            RuleFor(I => I.ConfirmPassword).Equal(I => I.Password).WithMessage("Parolalar eşleşmemektedir.");
            RuleFor(I => I.Email).NotNull().WithMessage("Email alanı boş geçilemez").EmailAddress().WithMessage("Lütfen geçerli bir email giriniz.");
            RuleFor(I => I.Name).NotNull().WithMessage("Ad alanı boş geçilemez");
            RuleFor(I => I.Surname).NotNull().WithMessage("Soyad alanı boş geçilemez");
        }
    }
}
