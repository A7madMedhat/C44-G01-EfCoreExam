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
    internal class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            #region Properties

            builder.Property(x => x.Title)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);
            builder.Property(x => x.Price)
                   .HasPrecision(8, 2);

            builder.ToTable(T => T.HasCheckConstraint("PublicationYearCheck", "[PublicationYear] between 1950 and YEAR(GETDATE())"));
            builder.ToTable(T => T.HasCheckConstraint("AvailableCopiesCheck", "[AvailableCopies] < [TotalCopies] or [AvailableCopies] = [TotalCopies] "));

            #endregion

            #region RelationShips

            builder.HasOne(B => B.Author)
                    .WithMany(A => A.Books)
                    .HasForeignKey(B => B.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(B => B.BookCategory)
                    .WithMany(C => C.Books)
                    .HasForeignKey(B => B.CategoryId);
            #endregion

        }
    }
}
