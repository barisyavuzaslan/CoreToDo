using CoreProject.ToDo.DTO.Dtos.ReportDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.BusinessLayer.ValidationRules.FluentValidation
{
    public class ReportAddValidator : AbstractValidator<ReportAddDto>
    {
        public ReportAddValidator()
        {
            RuleFor(I => I.Definition).NotNull().WithMessage("Tanım alanı boş geçilemez.");
            RuleFor(I => I.Details).NotNull().WithMessage("Detay alanı boş geçilemez");
        }
    }
}
