using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Models
{
    internal class Author : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        #region Author - Book

        #region Navigation Properties
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
        #endregion


        #endregion

    }
}
