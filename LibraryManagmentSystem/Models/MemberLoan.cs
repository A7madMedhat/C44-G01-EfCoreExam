using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Models
{
    internal class MemberLoan
    {
        #region MemberLoan - Book 

        public Book Book{ get; set; }

        public int BookId { get; set; }
        #endregion
        #region MemberLoan - Loan 

        public Loan Loan { get; set; }

        public int LoanId { get; set; }
        #endregion
        #region MemberLoan - Member 

        public Member Member { get; set; }

        public int MemberId { get; set; }
        #endregion

        public DateTime? DueDate { get; set; } = null!;
        public DateTime? ReturnDate { get; set; }
    }
}
