using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workers;

using WebApplication2.data.reposytorys;
using BuisnessLayer;
using BuisnessLayer.Interfaces;

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

        public LibraryCardController(ILibraryCardsRepository manager)
        {
            _libraryCardsRepository = manager;
        }

        [HttpPost]
        public string ChangeRefund([FromForm] int bookID, [FromForm] int personID, [FromForm] int days)
        {
            var rezult = _libraryCardsRepository.ChangeRefund(bookID, personID, days);
            _libraryCardsRepository.save();
            return rezult;
        }

        [HttpGet]
        public IEnumerable <string>  AllRefund()
        {
                 return _libraryCardsRepository.AllRefund();
        }

        [HttpPost]
        public IEnumerable <string> AllRefundPerson([FromBody]int userID) {
                return _libraryCardsRepository.AllRefundPerson(userID);
        }
        
    }
}
