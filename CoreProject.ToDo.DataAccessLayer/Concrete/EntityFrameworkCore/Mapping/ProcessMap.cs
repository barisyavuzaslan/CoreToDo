using CoreProject.ToDo.EntitiesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Mapping
{
    public class ProcessMap : IEntityTypeConfiguration<Process>
    {
        public void Configure(EntityTypeBuilder<Process> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(200);
            builder.Property(I => I.Desc).HasColumnType("ntext");
            builder.HasOne(I => I.Urgency).WithMany(I => I.Processes).HasForeignKey(I => I.UrgencyId);
        }
    }
}
