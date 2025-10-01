using Azure.Core.GeoJson;
using LibraryManagmentSystem.Contexts;
using LibraryManagmentSystem.Helper;
using LibraryManagmentSystem.Models;
using LibraryManagmentSystem.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryDbContext dbContext = new LibraryDbContext();

            LibraryDbContextSeed.DataSeed(dbContext);


            #region 9. Data Manipulation 

            #region  Retrieve the book title, its category title , and the author’s full name for all books whose price is greater than 300.

            //var result = dbContext.Books.Where(B => B.Price > 300).Select(B => new
            //{
            //    BookTile = B.Title,
            //    CategoryName = B.BookCategory.Title ,
            //    AuthorFullName = B.Author.FirstName + " " + B.Author.LastName
            //}).ToList();

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Retrieve All Authors And His/Her Books if Exists. 

            //var result = dbContext.Authors.Include(A => A.Books).ToList();

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.FirstName);
            //    foreach (var book in item.Books)
            //    {
            //        Console.WriteLine($"\t Book Name =  {book.Title}");
            //    }
            //}

            #endregion

            #region Member with id 1 Want To Borrow The Book With Id 2 And He Will Return it After 5 Days 

            //bool falg = LoanManagment.BorrowBook(1,2,5,dbContext);
            //if(falg)
            //{
            //    Console.WriteLine("The Book IS Borrowed Successfully");
            //}

            #endregion

            #region After 10 Days Member with id 1 Returned The Book

            //bool flag = LoanManagment.ReturnBook(1, 2, 10, dbContext);
            //if(flag)
            //    Console.WriteLine("Returned");

            #endregion

            #region Retrieve all members who currently have active loans (i.e., loans that have not yet been returned)
            //var activeMembers = dbContext.Members
            //                             .Where(m => m.MemberBookLoans
            //                                 .Any(ml => ml.ReturnDate == null && ml.Loan.Status == LoanStatus.Borrowed))
            //                             .Select(m => new
            //                             {
            //                                 MemberId = m.Id,
            //                                 MemberName = m.Name,
            //                                 ActiveLoans = m.MemberBookLoans
            //                                     .Where(ml => ml.ReturnDate == null && ml.Loan.Status == LoanStatus.Borrowed)
            //                                     .Select(ml => new
            //                                     {
            //                                         LoanId = ml.Loan.Id,
            //                                         LoanDate = ml.Loan.LoanDate,
            //                                         DueDate = ml.DueDate,
            //                                         BookTitle = ml.Book.Title
            //                                     }).ToList()
            //                             })
            //                             .ToList();
            //foreach (var item in activeMembers)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #endregion



        }
    }
}
