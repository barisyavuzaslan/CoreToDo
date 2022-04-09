using CoreProject.ToDo.EntitiesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Mapping
{
    public class UrgencyMap : IEntityTypeConfiguration<Urgency>
    {
        public void Configure(EntityTypeBuilder<Urgency> builder)
        {
            builder.Property(I => I.Definition).HasMaxLength(100);

        }
    }
}
