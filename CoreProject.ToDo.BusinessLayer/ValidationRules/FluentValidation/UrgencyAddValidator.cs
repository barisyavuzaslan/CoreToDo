using CoreProject.ToDo.DTO.Dtos.UrgencyDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.ValidationRules.FluentValidation
{
    public class UrgencyAddValidator : AbstractValidator<UrgencyAddDto>
    {
        public UrgencyAddValidator()
        {
            RuleFor(I => I.Definition).NotNull().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
