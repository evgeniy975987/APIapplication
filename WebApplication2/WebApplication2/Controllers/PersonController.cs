using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication2.Models;
using Workers;

using WebApplication2.data.reposytorys;
using BuisnessLayer;
using BuisnessLayer.Interfaces;

namespace WebApplication2.Controllers
{
    [Route("newModels/Person")]
    [ApiController]

    
    public class PersonController : ControllerBase
    {
        /// <summary>
        /// метод  GetBooks - 6.1.5.	Получить список всех взятых пользователем книг 
        /// метод NewPerson - 6.1.1.	добавить пользователя
        /// мтод AllBooksPerson - 6.1.5.	Получить список всех взятых пользователем книг 
        /// метод NewLibraryCards - 6.1.6 выдать пользователю книгу
        /// метод DeleteBookLibrary -  6.1.7 вернуть книгу которая была получена пользователем
        /// методы DeletePerson - 6.1.4 и 6.1.3 удаляют пользователя по ID и по ФИО
        /// </summary>
        IPersonRepository _personRepository;
       
        public PersonController(IPersonRepository person)
        {
            _personRepository = person;
        }

       

        [HttpPost("newPerson")]
        public string NewPerson([FromForm] DateTime birthDay, [FromForm] string firstName, [FromForm] string middleName, [FromForm] string lastName)
        {
           var rezult = _personRepository.NewPerson(birthDay, firstName, middleName, lastName);
            _personRepository.Save();
            return rezult;


        }
        [HttpPost("editPerson")]
        public string ChangePerson([FromForm] string firstName, [FromForm] string middleName, [FromForm] string lastName, [FromForm] DateTime birthday, [FromForm] int personID)
        {
            var rezult = _personRepository.ChangePerson(firstName, middleName, lastName, personID, birthday);
            _personRepository.Save();
            return rezult;
        }
        [HttpDelete("deletePerson")]
        public bool DeletePerson([FromForm] int PersonID) 
        {
            var rezult = _personRepository.DeletePerson(PersonID);
            _personRepository.Save();
            return rezult;
        }
        
        [HttpDelete("delete")]
        public  bool DeletePerson([FromForm] string firstName, [FromForm] string middleName, [FromForm] string lastName)
        {
            var rezult = _personRepository.DeletePerson(firstName, middleName, lastName);
            _personRepository.Save();
            return rezult;
            
        }

        
        [HttpPost("newLibraryCards")]
        public string NewLibraryCards([FromForm] int bookID, [FromForm] int personID)
        {
            var rezult = _personRepository.NewLibraryCard(personID, bookID); ;
            _personRepository.Save();
            return rezult;
        }

        [HttpDelete("deleteBookLibrary")]
        public string DeleteLibraryCard([FromForm] int bookID, [FromForm] int personID)
        {
            var rezult = _personRepository.DeleteLibraryCard(bookID, personID);
            _personRepository.Save();
            return rezult;
        }

        [HttpGet("AllBooksPerson")]
        public IEnumerable<string> AllBooksPerson([FromForm] int personID) {
           return _personRepository.AllbooksPerson(personID);
        }
    }
}
