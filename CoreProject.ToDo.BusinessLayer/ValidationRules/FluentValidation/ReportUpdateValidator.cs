using CoreProject.ToDo.DTO.Dtos.ReportDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.ValidationRules.FluentValidation
{
    public class ReportUpdateValidator : AbstractValidator<ReportUpdateDto>
    {
        public ReportUpdateValidator()
        {
            RuleFor(I => I.Definition).NotNull().WithMessage("Tanım alanı boş geçilemez.");
            RuleFor(I => I.Details).NotNull().WithMessage("Detay alanı boş geçilemez");
        }
    }
}
