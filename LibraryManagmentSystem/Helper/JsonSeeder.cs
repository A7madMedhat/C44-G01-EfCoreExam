using LibraryManagmentSystem.Contexts;
using LibraryManagmentSystem.Models;
using LibraryManagmentSystem.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Helper
{


    public static class LoanManagment
    {
        internal static bool BorrowBook(int MId, int BId, int BorrowDays, LibraryDbContext dbContext)
        {
            try
            {

                var Member = dbContext.Members.Find(MId);
                if (Member is null || Member.Status == MemberStatus.Suspended) return false;

                var Book = dbContext.Books.Find(BId);
                if (Book is null || Book.AvailableCopies == 0) return false;

                Loan Loan = new Loan();

                dbContext.Loans.Add(Loan);

                MemberLoan memberLoan = new MemberLoan()
                {
                    MemberId = MId,
                    BookId = BId,
                    Loan = Loan,
                    DueDate = DateTime.Now.AddDays(BorrowDays)
                };

                dbContext.Set<MemberLoan>().Add(memberLoan);

                Book.AvailableCopies--;

                dbContext.SaveChanges();
                return true;


            }
            catch
            {
                return false;
            }
        }

        internal static bool ReturnBook(int MId, int BId, int ReturnDays, LibraryDbContext dbContext)
        {
            try
            {
                var memeber = dbContext.Members.Find(MId);
                var book = dbContext.Books.Find(BId);
                if (book is null && book is null) return false;

                var memberloan = dbContext.Set<MemberLoan>().FirstOrDefault(M => M.MemberId == MId && M.BookId == BId && M.ReturnDate == null);
                if (memberloan is null) return false;
                var actualReturnDate = memberloan?.DueDate!.Value.AddDays(ReturnDays);
                book.AvailableCopies++;

                memberloan!.ReturnDate = actualReturnDate;
                var loan = dbContext.Loans.FirstOrDefault(l => l.Id == memberloan.LoanId);
                if (loan is null) return false;

                if (actualReturnDate > memberloan?.DueDate)
                {
                    var fine = new Fine()
                    {
                        LoanId = loan.Id,
                        Amount = book.Price * 0.05M,
                        IssuedDate = DateTime.Now,
                        Status = FineStatus.Pending
                    };
                    dbContext.Fines.Add(fine);
                    loan!.Status = LoanStatus.Overdue;
                }
                else
                {
                    loan!.Status = LoanStatus.Returned;
                }
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }


    }
    internal static class JsonSeeder
    {
        public static List<T> JsonToList<T>(string Path)
        {

            var FoundFile = File.Exists(Path);
            if (FoundFile == false) throw new DirectoryNotFoundException();

            var Data = File.ReadAllText(Path);

            if (string.IsNullOrWhiteSpace(Data)) return new List<T>();

            var Options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            Options.Converters.Add(new JsonStringEnumConverter());

            return JsonSerializer.Deserialize<List<T>>(Data, Options) ?? new List<T>();


        }
    }
}
