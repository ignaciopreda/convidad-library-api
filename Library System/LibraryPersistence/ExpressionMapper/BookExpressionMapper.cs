using LibraryPersistence.Entities;
using LibraryPersistence.Filters;
using LibraryPersistence.Mappers;
using LibraryPersistence.Predicates;
using System;
using System.Linq.Expressions;

namespace LibraryPersistence.ExpressionMapper
{
    public class BookExpressionMapper : IExpressionMapperPersistence<Book, BookFiltersModel>
    {
        public Expression<Func<Book, bool>> CreateExpression(BookFiltersModel bookFilterModel)
        {
            Expression<Func<Book, bool>> filterPersistence = book => true;

            if (!string.IsNullOrEmpty(bookFilterModel.BookTitle))
            {
                Expression<Func<Book, bool>> filterAuthorName = 
                    book => book.Title.Contains(bookFilterModel.BookTitle);

                filterPersistence = filterPersistence.And(filterAuthorName);
            }

            if (!string.IsNullOrEmpty(bookFilterModel.BookIsbn))
            {
                Expression<Func<Book, bool>> filterAuthorName =
                    book => book.Isbn.Contains(bookFilterModel.BookIsbn);

                filterPersistence = filterPersistence.And(filterAuthorName);
            }

            if (!string.IsNullOrEmpty(bookFilterModel.AuthorName))
            {
                Expression<Func<Book, bool>> filterAuthorName =
                    book => book.Author.Name.Contains(bookFilterModel.AuthorName);

                filterPersistence = filterPersistence.And(filterAuthorName);
            }

            return filterPersistence;
        }
    }
}
