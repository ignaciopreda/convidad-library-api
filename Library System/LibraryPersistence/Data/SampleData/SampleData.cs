using LibraryPersistence.Entities;
using System.Collections.Generic;
using System;

namespace LibraryPersistence.Data.SampleData
{
    public class SampleData
    {
        public static List<Author> Authors = new List<Author>
        {
            new Author
            {
                Id = 1,
                Name = "J.K. Rowling",
                Nationality = "British",
                BirthDate = new DateTime(1965, 7, 31),
                Books = new List<Book>
                {
                    new Book
                    {
                        Id = 1,
                        Title = "Harry Potter and the Philosopher's Stone",
                        Isbn = "9780747532743",
                        PublicationDate = new DateTime(1997, 6, 26)
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Harry Potter and the Chamber of Secrets",
                        Isbn = "9780747538493",
                        PublicationDate = new DateTime(1998, 7, 2)
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Harry Potter and the Prisoner of Azkaban",
                        Isbn = "9780747542155",
                        PublicationDate = new DateTime(1999, 7, 8)
                    }
                }
            },
            new Author
            {
                Id = 2,
                Name = "J.R.R. Tolkien",
                Nationality = "British",
                BirthDate = new DateTime(1892, 1, 3),
                Books = new List<Book>
                {
                    new Book
                    {
                        Id = 4,
                        Title = "The Lord of the Rings",
                        Isbn = "9780007124011",
                        PublicationDate = new DateTime(1954, 7, 29)
                    },
                    new Book
                    {
                        Id = 5,
                        Title = "The Hobbit",
                        Isbn = "9780547928227",
                        PublicationDate = new DateTime(1937, 9, 21)
                    }
                }
            },
            new Author
            {
                Id = 3,
                Name = "Stephen King",
                Nationality = "American",
                BirthDate = new DateTime(1947, 9, 21),
                Books = new List<Book>
                {
                    new Book
                    {
                        Id = 6,
                        Title = "The Shining",
                        Isbn = "9780307743657",
                        PublicationDate = new DateTime(1977, 1, 28)
                    },
                    new Book
                    {
                        Id = 7,
                        Title = "It",
                        Isbn = "9780670813025",
                        PublicationDate = new DateTime(1986, 9, 15)
                    }
                }
            }
        };
    }
}
