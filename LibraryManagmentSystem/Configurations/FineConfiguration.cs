using LibraryManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Configurations
{
    internal class FineConfiguration : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> builder)
        {

            builder.Property(x => x.Amount)
                    .HasPrecision(8, 2);

            builder.Property(x => x.IssuedDate)
                    .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.Status)
            .HasConversion<string>()
            .HasMaxLength(7);
        }
    }
}
