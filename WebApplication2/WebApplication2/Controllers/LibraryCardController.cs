using BuisnessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("newModels/LibraryCards")]
    [ApiController]
    public class LibraryCardController : ControllerBase
    {

        /// <summary>
        /// DatesRefund() //Возвращает всех должников
        /// </summary>

        ILibraryCardsRepository _libraryCardsRepository;

        public LibraryCardController(ILibraryCardsRepository libraryCardsRepository)
        {
            _libraryCardsRepository = libraryCardsRepository;
        }

        [HttpPost]
        public string ChangeRefund([FromForm] int bookID, [FromForm] int personID, [FromForm] int days)
        {
            var rezult = _libraryCardsRepository.ChangeRefund(bookID, personID, days);
            return rezult;
        }

        [HttpGet]
        public string  AllRefund()
        {
                 return _libraryCardsRepository.AllRefund();
        }

        [HttpGet("AllRefundPerson")]
        public string AllRefundPerson([FromForm]int userID) {
                return _libraryCardsRepository.AllRefundPerson(userID);
        }
        
    }
}
