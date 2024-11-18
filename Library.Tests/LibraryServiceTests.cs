using Library.Core.Contracts;
using Library.Core.Models;
using Library.Core.Services;
using Moq;

namespace Library.Tests
{
    public class LibraryServiceTests
    {
        [Fact]
        public void AddBookTest()
        {
            //Arrange
            Book bookSample = new Book
            {
                Author = "John D. Doe",
                Name = "Tales for kids",
                ReleaseYear = 1995,
                LibraryId = 12,
            };

            Mock<ILibraryRepository> libraryRepositoryMock = new Mock<ILibraryRepository>();
            libraryRepositoryMock.Setup(x => x.AddBook(bookSample));
            ILibraryService libraryService = new LibraryService(libraryRepositoryMock.Object);

            //Act
            libraryService.AddLibraryItem(bookSample);

            //Assert
            libraryRepositoryMock.Verify(x => x.AddBook(It.IsAny<Book>()), Times.Once);
            libraryRepositoryMock.Verify(x => x.AddMagazine(It.IsAny<Magazine>()), Times.Never);
        }

        [Fact]
        public void GetAllBooksTest()
        {
            //Arrange
            Book bookSample1 = new Book
            {
                Author = "John D. Doe",
                Name = "Tales for kids",
                ReleaseYear = 1995,
                LibraryId = 12,
            };
            Book bookSample2 = new Book
            {
                Author = "John D. Doe",
                Name = "Tales for kids 2",
                ReleaseYear = 2008,
                LibraryId = 18,
            };
            List<Book> booksExpected = new List<Book>();
            booksExpected.Add(bookSample1);
            booksExpected.Add(bookSample2);


            Mock<ILibraryRepository> libraryRepositoryMock = new Mock<ILibraryRepository>();
            libraryRepositoryMock.Setup(x => x.GetAllBooks().Result).Returns(booksExpected);
            ILibraryService libraryService = new LibraryService(libraryRepositoryMock.Object);

            //Act
            var result = libraryService.GetAllBooks().Result;

            //Assert
            libraryRepositoryMock.Verify(x => x.GetAllBooks(), Times.Once);
            libraryRepositoryMock.Verify(x => x.GetAllMagazines(), Times.Never);

            Assert.Contains<Book>(bookSample1,result);
            Assert.Equal(result.Count, booksExpected.Count);
        }

        [Fact]
        public void AddMagazineTest()
        {
            //Arrange
            Magazine magSample = new Magazine
            {
                Publisher = "FamousPub",
                Name = "Sample Mag",
                ReleaseYear = 2024,
                LibraryId = 12,
                SerialNumber = 9,
            };

            Mock<ILibraryRepository> libraryRepositoryMock = new Mock<ILibraryRepository>();
            libraryRepositoryMock.Setup(x => x.AddMagazine(magSample));
            ILibraryService libraryService = new LibraryService(libraryRepositoryMock.Object);

            //Act
            libraryService.AddLibraryItem(magSample);

            //Assert
            libraryRepositoryMock.Verify(x => x.AddBook(It.IsAny<Book>()), Times.Never);
            libraryRepositoryMock.Verify(x => x.AddMagazine(It.IsAny<Magazine>()), Times.Once);
        }

        [Fact]
        public void GetLibraryItemById()
        {
            //Arrange
            Book bookSample1 = new Book
            {
                Author = "John D. Doe",
                Name = "Tales for kids",
                ReleaseYear = 1995,
                LibraryId = 14,
            };
            Magazine magSample = new Magazine
            {
                Publisher = "FamousPub",
                Name = "Sample Mag",
                ReleaseYear = 2024,
                LibraryId = 12,
                SerialNumber = 9,
            };


            Mock<ILibraryRepository> libraryRepositoryMock = new Mock<ILibraryRepository>();
            libraryRepositoryMock.Setup(x => x.GetMagazineById(12).Result).Returns(magSample);
            libraryRepositoryMock.Setup(x => x.GetBookById(14).Result).Returns(bookSample1);
            ILibraryService libraryService = new LibraryService(libraryRepositoryMock.Object);

            //Act
            var resultBook = libraryService.GetBookById(14).Result;
            var resultMagazine = libraryService.GetMagazineById(12).Result;
            var resultNull = libraryService.GetMagazineById(18).Result;

            //Assert


            Assert.Equal(resultBook, bookSample1);
            Assert.Equal(resultMagazine, magSample);
            Assert.Null(resultNull);
            
        }
    }
}