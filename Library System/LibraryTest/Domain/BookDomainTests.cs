using AutoMapper;
using LibraryCommon.Handlers.ErrorHandling;
using LibraryDomain.Authors;
using LibraryDomain.Dtos.Requests;
using LibraryDomain.Dtos.Responses;
using LibraryInfrastructure.NationalLibraryApi;
using LibraryPersistence.Entities;
using LibraryPersistence.Persistence.Authors;
using LibraryPersistence.Persistence.Books;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LibraryTest.Domain
{
    public class BookDomainTests
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly INationalLibraryApiClient _nationalLibraryApiClient;
        private readonly IConfiguration _configuration;

        private BookDomain Target { get; set; }
        
        public BookDomainTests()
        {
            _bookRepository = Mock.Of<IBookRepository>();
            _authorRepository = Mock.Of<IAuthorRepository>();
            _mapper = Mock.Of<IMapper>();
            _nationalLibraryApiClient = Mock.Of<INationalLibraryApiClient>();
            _configuration = Mock.Of<IConfiguration>();

            Target = new BookDomain(
                _mapper,
                _bookRepository,
                _authorRepository,
                _nationalLibraryApiClient,
                _configuration
                );
        }

        public class Method_AddBookAsync : BookDomainTests
        {
            private Author _author;
            private readonly CreateBookDto _createBookDto;
            public Method_AddBookAsync()
            {
                _createBookDto = new CreateBookDto() {
                    Title = "Iron Man",
                    PublicationDate = DateTime.UtcNow,
                    Isbn = "12345",
                    AuthorId = 3
                };
            }

            [Fact]
            public async Task GetByIdAsync_Method_From_Repository_Is_Called_Once()
            {
                // Arrange
                var _author = new Author() {
                    Id = 1
                };

                Mock.Get(_authorRepository)
                    .Setup(a => a.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(_author);

                // Act
                await Target.AddBookAsync(_createBookDto);

                // Assert
                Mock.Get(_authorRepository)
                    .Verify(br => br.GetByIdAsync(It.IsAny<int>()), Times.Once);
            }

            [Fact]
            public async Task If_Author_From_GetByIdAsync_Method_Is_Null_Return_NotFoundException()
            {
                // Arrange
                _author = null;

                Mock.Get(_authorRepository)
                    .Setup(a => a.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(_author);

                // Act

                // Assert
                await Assert.ThrowsAsync<NotFoundException>(() => Target.AddBookAsync(_createBookDto));
            }

            [Fact]
            public async Task Map_Method_As_Book_Type_From_Mapper_Is_Called_Once()
            {
                // Arrange
                var _author = new Author() {
                    Id = 1
                };

                Mock.Get(_authorRepository)
                    .Setup(a => a.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(_author);

                // Act
                await Target.AddBookAsync(_createBookDto);

                // Assert
                Mock.Get(_mapper).Verify(m => m.Map<Book>(It.IsAny<CreateBookDto>()), Times.Once);
            }

            [Fact]
            public async Task AddBookAsync_Method_From_BookRepository_Is_Called_Once()
            {
                // Arrange
                var _author = new Author() {
                    Id = 1
                };

                Mock.Get(_authorRepository)
                    .Setup(a => a.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(_author);

                // Act
                await Target.AddBookAsync(_createBookDto);

                // Assert
                Mock.Get(_bookRepository).Verify(br => br.AddBookAsync(It.IsAny<Book>()), Times.Once);
            }

            [Fact]
            public async Task Map_Method_As_CreatedBookDto_Type_From_Mapper_Is_Called_Once()
            {
                // Arrange
                var _author = new Author()
                {
                    Id = 1
                };

                Mock.Get(_authorRepository)
                    .Setup(a => a.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(_author);

                // Act
                await Target.AddBookAsync(_createBookDto);

                // Assert
                Mock.Get(_mapper).Verify(m => m.Map<CreatedBookDto>(It.IsAny<Book>()), Times.Once);
            }

            [Fact]
            public async Task AddBookAsync_Method_Returns_A_CreatedBookDto_Type()
            {
                // Arrange
                var author = new Author() {
                    Id = 1
                };

                var book = new Book() {
                    Id = 1
                };

                var createdBookDto = new CreatedBookDto()
                {
                    Id = 1
                };

                Mock.Get(_authorRepository)
                    .Setup(a => a.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(author);

                Mock.Get(_mapper)
                    .Setup(m => m.Map<Book>(_createBookDto))
                    .Returns(book);

                Mock.Get(_bookRepository)
                    .Setup(b => b.AddBookAsync(book))
                    .ReturnsAsync(book);

                Mock.Get(_mapper)
                    .Setup(m => m.Map<CreatedBookDto>(book))
                    .Returns(createdBookDto);

                // Act
                var result = await Target.AddBookAsync(_createBookDto);

                // Assert
                Assert.IsType<CreatedBookDto>(result);
            }


        }

    }
}
