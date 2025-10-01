using LibraryManagmentSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Models
{
    internal class Fine : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? PaidDate { get; set; } = null!;
        public FineStatus Status { get; set; }

        #region Loan - Fine
        #region Navigation Properties

        public Loan Loan { get; set; } = null!;
        #endregion

        public int LoanId { get; set; }

        #endregion

    }

}
