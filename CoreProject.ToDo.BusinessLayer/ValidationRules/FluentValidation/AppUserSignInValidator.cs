using CoreProject.ToDo.DTO.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator:AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(I => I.Password).NotNull().WithMessage("Şifre alanı boş geçilemez.");
        }
    }
}
