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
    internal class MemberLoanConfiguration : IEntityTypeConfiguration<MemberLoan>
    {
        public void Configure(EntityTypeBuilder<MemberLoan> builder)
        {
            builder.HasKey(X => new { X.MemberId, X.LoanId, X.BookId });
        }
    }
}
