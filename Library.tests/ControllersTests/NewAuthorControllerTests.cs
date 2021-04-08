using Library.Insert.Data;
using WebApplication2.Controllers;
using WebApplication2.data.reposytorys;
using Xunit;

namespace Library.tests.ControllersTests
{
    public class NewAuthorControllerTests
    {

        static DataInsertTest _context = new DataInsertTest();
        static AuthorRepository _authorRepository = new AuthorRepository(_context);
        static NewAuthorController _authorsController = new NewAuthorController(_authorRepository);

        [Fact]
        public static void FindBook_21_true_NotEmpty()
        {
            int year = 1857;
            bool sort = true;
            var rezult = _authorsController.FindBooks(year, sort);
            Assert.NotEmpty(rezult);
        }
        [Fact]
        public static void FindText_NotEmpty()
        {
            string findText = "ДАТА";
            var rezult = _authorsController.FindTitleBook(findText);
            Assert.NotEmpty(rezult);
        }
    }
}
