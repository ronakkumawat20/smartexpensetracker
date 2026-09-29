using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SET.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SET.Infrastructure.Configuration
{
    public class FaqConfiguration : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> builder)
        {
            builder.Property(e => e.UniqueId).IsRequired().HasDefaultValueSql("NEWID()");
            builder.Property(e => e.FaqQuestion).IsRequired().HasMaxLength(500);
            builder.Property(e => e.FaqAnswer).IsRequired().HasMaxLength(5000);
            builder.Property(e => e.CreatedByProgram).IsRequired().HasMaxLength(100);
            builder.Property(e => e.CreatedBy).IsRequired().HasMaxLength(100);
            builder.Property(e => e.CreatedDate).IsRequired().HasColumnType("datetime").HasDefaultValueSql("(getdate())");
        }
    }
}
