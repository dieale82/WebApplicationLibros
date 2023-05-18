using Models;
using Moq;
using NUnit.Framework;

namespace Queries.Test
{
    public class BookQueryTest
    {
        [Test]
        public void GetAllBooksFromListTest()
        {
            // Arrange
            var bookQueryMock = new Mock<IGetBookList>();
            bookQueryMock.Setup(c => c.Handle()).ReturnsAsync(BookQueryTestData.GetBooks());

            // Act
            var mockedQuery = bookQueryMock.Object.Handle();

            // Assert
            Assert.AreEqual("Libro 1", mockedQuery.Result.First().Titulo);
            Assert.AreEqual(4, mockedQuery.Result.Count());
        }

        [Test]
        public void GetAllBooksFromListWithWrongFilterTest()
        {
            // Arrange
            var bookToValidate = new Libro
            {
                EditorialId = 1,
                Titulo = "Libro 6",
                Sinopsis = "A test book6",
                NPaginas = "300"
            };

            var bookQueryMock = new Mock<IGetBookList>();
            bookQueryMock.Setup(c => c.Handle()).ReturnsAsync(BookQueryTestData.GetBooks());

            // Act
            var mockedQuery = bookQueryMock.Object.Handle();

            // Assert
            CollectionAssert.DoesNotContain(mockedQuery.Result, bookToValidate);
        }

        [Test]
        public void CreateNewBook()
        {
            // Arrange
            var bookToValidate = new Libro
            {
                EditorialId = 1,
                Titulo = "Libro 7",
                Sinopsis = "A test book 7",
                NPaginas = "400",
                Autores = BookQueryTestData.GetAuthors().Skip(2).Take(1).ToList()
            };

            var bookQueryMock = new Mock<ICreateBook>();
            bookQueryMock.Setup(c => c.Handle(bookToValidate)).ReturnsAsync(1);

            // Act
            var mockedQuery = bookQueryMock.Object.Handle(bookToValidate);

            // Assert
            Assert.That(mockedQuery.Result, Is.TypeOf<int>());
            Assert.AreEqual(mockedQuery.Result, 1);
        }

        [Test]
        public void CreateNewBookWithEmptyValue()
        {
            // Arrange
            Libro bookToValidate = null;

            var bookQueryMock = new Mock<ICreateBook>();
            bookQueryMock.Setup(c => c.Handle(bookToValidate)).ThrowsAsync(new ArgumentNullException("Data is empty"));

            // Act
            var mockedQuery = bookQueryMock.Object.Handle(bookToValidate);

            // Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => {await bookQueryMock.Object.Handle(bookToValidate); });
        }
    }
}
