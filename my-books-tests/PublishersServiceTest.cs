using Microsoft.EntityFrameworkCore;
using my_books_v2.Data;
using my_books_v2.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace my_books_tests
{
    public class PublishersServiceTest
    {
        private static DbContextOptions<AppDBContext> dbContextOptions = new DbContextOptionsBuilder<AppDBContext>()
            .UseInMemoryDatabase(databaseName: "BookDbTest")
            .Options;

        AppDBContext context;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new AppDBContext(dbContextOptions);
            context.Database.EnsureCreated();

            seedDatabase();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        private void seedDatabase()
        {
            var publishers = new List<Publisher>
            {
                new Publisher()
                {
                    Id = 1,
                    Name = "Publisher 1"
                },
                new Publisher()
                {
                    Id = 2,
                    Name = "Publisher 2"
                },
                 new Publisher()
                {
                    Id = 3,
                    Name = "Publisher 3"
                }
            };
            context.Publishers.AddRange(publishers);

            var authors = new List<Author>
            {
                new Author()
                {
                    Id = 1,
                    FullName = "Author 1"
                },
                new Author()
                {
                    Id = 2,
                    FullName = "Author 2"
                }
            };
            context.Authors.AddRange(authors);

            var books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Book 1 Title",
                    Description = "Book 1 Description",
                    IsRead = false,
                    Genre = "Genre",
                    CoverUrl = "https://...",
                    DateAdded = DateTime.Now.AddDays(-10),
                    PublisherId = 1
                },
                new Book()
                {
                    Id = 2,
                    Title = "Book 2 Title",
                    Description = "Book 2 Description",
                    IsRead = false,
                    Genre = "Genre",
                    CoverUrl = "https://...",
                    DateAdded = DateTime.Now.AddDays(-10),
                    PublisherId = 1
                }
            };
            context.Books.AddRange(books);

            var books_authors = new List<Book_Author>()
            {
                new Book_Author()
                {
                    Id = 1,
                    BookId = 1,
                    AuthorId = 1
                },
                new Book_Author()
                {
                    Id = 2,
                    BookId = 1,
                    AuthorId = 2
                },
                new Book_Author()
                {
                    Id = 3,
                    BookId = 2,
                    AuthorId = 2
                },
            };
            context.Book_Authors.AddRange(books_authors);

            context.SaveChanges();
        }


    }
}