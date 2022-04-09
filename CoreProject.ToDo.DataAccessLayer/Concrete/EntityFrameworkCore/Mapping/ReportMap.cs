using CoreProject.ToDo.EntitiesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Mapping
{
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Definition).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Details).HasColumnType("ntext");

            builder.HasOne(I => I.Process).WithMany(I => I.Reports).HasForeignKey(I => I.ProcessId);
        }
    }
}
