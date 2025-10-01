using LibraryManagmentSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Models
{
    internal class Member : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime MembershipDate { get; set; }
        public MemberStatus Status { get; set; }

        #region MemberLoan - Member 

        public ICollection<MemberLoan> MemberBookLoans { get; set; } = new HashSet<MemberLoan>();
        #endregion
    }
}
