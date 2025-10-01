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
    internal class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(x => x.Name)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
            builder.Property(x => x.Email)
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
            builder.ToTable(T => T.HasCheckConstraint("ValidEmailCheck", "[Email] Like '_%@_%._%'"));

            builder.Property(x => x.PhoneNumber)
                    .HasColumnType("varchar")
                    .HasMaxLength(11);
            builder.ToTable(t =>
                t.HasCheckConstraint("ValidEgyptianPhoneNumberCheck", "[PhoneNumber] LIKE '01%' AND [PhoneNumber] NOT LIKE '%[^0-9]%'"));

            builder.Property(x => x.Address)
                    .HasColumnType("varchar")
                    .HasMaxLength(100);

            builder.Property(x => x.MembershipDate)
                    .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.Status)
                    .HasConversion<string>()
                    .HasMaxLength(9);

        }
    }
}
