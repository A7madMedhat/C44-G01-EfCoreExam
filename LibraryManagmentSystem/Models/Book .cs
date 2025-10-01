using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Models
{
    internal class Book :BaseEntity
    {
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public int PublicationYear { get; set; }

        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }

        #region Author - Book

        #region Navigation Properties
        public Author Author { get; set; }
        #endregion
        #region FK
        public int AuthorId { get; set; }
        #endregion

        #endregion

        #region Category - Book

        #region Navigation Properties
        public Category BookCategory { get; set; }
        #endregion

        #region FK
        public int CategoryId { get; set; }
        #endregion

        #endregion

        #region MemberLoan - Book 

        public ICollection<MemberLoan> MemberBookLoans { get; set; } = new HashSet<MemberLoan>();
        #endregion

    }
}
