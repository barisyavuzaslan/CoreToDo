using CoreProject.ToDo.DTO.Dtos.ProcessDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.ValidationRules.FluentValidation
{
    public class ProcessAddValidator : AbstractValidator<ProcessAddDto>
    {
        public ProcessAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad alanı gereklidir.");
            RuleFor(I => I.UrgencyId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen bir aciliyet durumu seçiniz");
        }
    }
}
