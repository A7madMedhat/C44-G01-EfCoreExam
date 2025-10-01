using LibraryManagmentSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Models
{
    internal class Loan : BaseEntity
    {
        public DateTime LoanDate { get; set; }
        public LoanStatus Status { get; set; }

        #region Loan - Fine

        #region Navigation Properties

        public Fine? Fine { get; set; }
        #endregion

        #endregion

        #region MemberLoan - Loan 

        public ICollection<MemberLoan> MemberBookLoans { get; set; } = new HashSet<MemberLoan>();
        #endregion

    }
}
