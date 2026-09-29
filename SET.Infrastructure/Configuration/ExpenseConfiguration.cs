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
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Property(e => e.Title).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(e => e.Category).IsRequired().HasMaxLength(50);
            builder.Property(e => e.ExpenseDate).HasColumnType("date");
            builder.Property(e => e.IsRecurring).HasDefaultValue(false);
            //builder.Property(e => e.ReceiptPath).HasMaxLength(200);
            //builder.Property(e => e.title).IsRequired() .HasMaxLength(50)
        }

    }
}
