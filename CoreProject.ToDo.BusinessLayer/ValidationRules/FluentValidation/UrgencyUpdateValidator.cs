using CoreProject.ToDo.DTO.Dtos.UrgencyDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.ValidationRules.FluentValidation
{
    public class UrgencyUpdateValidator : AbstractValidator<UrgencyUpdateDto>
    {
        public UrgencyUpdateValidator()
        {
            RuleFor(I => I.Definition).NotNull().WithMessage("Tanım alanı boş geçilemez.");
        }
    }
}
