using LibraryManagmentSystem.Helper;
using LibraryManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Contexts
{
    internal static class LibraryDbContextSeed
    {
        //public static 
        public static bool DataSeed(LibraryDbContext dbContext)
        {
            try
            {

                // Check The File Empty Or Not
                bool HasAuthors = dbContext.Authors.Any();
                bool HasCategories = dbContext.Categories.Any();
                bool HasMemebers = dbContext.Members.Any();
                bool HasBooks = dbContext.Books.Any();

                if (!HasAuthors && HasCategories && HasMemebers && HasBooks) return false;

                //var Tran = dbContext.Database.BeginTransaction();

                if (!HasAuthors)
                {
                    var Authors = JsonSeeder.JsonToList<Author>("D:\\Route_Aliaa_Tarek\\Eng Aliaa Tarek\\06 Entity Framework Core\\Exam\\Files\\Authors.json");
                    dbContext.AddRange(Authors);
                }

                if (!HasCategories)
                {
                    var Categories = JsonSeeder.JsonToList<Category>("D:\\Route_Aliaa_Tarek\\Eng Aliaa Tarek\\06 Entity Framework Core\\Exam\\Files\\Categories.json");
                    dbContext.AddRange(Categories);
                }
                    dbContext.SaveChanges();

                if (!HasBooks)
                {
                    var Books = JsonSeeder.JsonToList<Book>("D:\\Route_Aliaa_Tarek\\Eng Aliaa Tarek\\06 Entity Framework Core\\Exam\\Files\\Books.json");
                    dbContext.AddRange(Books);
                }

                if (!HasMemebers)
                {
                    var Memebers = JsonSeeder.JsonToList<Member>("D:\\Route_Aliaa_Tarek\\Eng Aliaa Tarek\\06 Entity Framework Core\\Exam\\Files\\Members.json");
                    dbContext.AddRange(Memebers);
                }
                dbContext.SaveChanges();

                //Tran.Commit();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
