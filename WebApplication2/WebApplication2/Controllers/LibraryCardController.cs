using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workers;

using WebApplication2.data.reposytorys;
using BuisnessLayer;

namespace WebApplication2.Controllers
{
    [Route("newModels/LibraryCards")]
    [ApiController]
    public class LibraryCardController : ControllerBase
    {

        /// <summary>
        /// DatesRefund() //Возвращает всех должников
        /// </summary>

        DataManager _manager;

        public LibraryCardController(DataManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public string UpdateLibreryCard([FromForm] int bookID, [FromForm] int personID, [FromForm] int days)
        {
            var rezult = _manager._libraryCardsRepository.ChangeRefund(bookID, personID, days);
            _manager._libraryCardsRepository.save();
            return rezult;
        }

        [HttpGet]
        public IEnumerable <string>  DatesRefund()
        {
                 return _manager._libraryCardsRepository.AllRefund();
        }

        [HttpPost]
        public IEnumerable <string> CheakRefundPerson([FromBody]int userID) {
                return _manager._libraryCardsRepository.AllRefundPerson(userID);
        }
        
    }
}
