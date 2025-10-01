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
    internal class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Title)
                               .HasColumnType("varchar")
                               .HasMaxLength(50);
            builder.Property(x => x.Description)
                               .HasColumnType("varchar")
                               .HasMaxLength(100);
        }
    }
}
