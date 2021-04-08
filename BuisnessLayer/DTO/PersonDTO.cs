using System;
using System.Collections.Generic;
using WebApplication2.Entitys;

namespace BuisnessLayer.DTO
{
    [Serializable]
    class PersonDTO
    {

        public int PersonID { get; set; }
        public DateTime BirthDay { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public List<LibraryCardsDTO> LibraryCards { get; set; }


        public PersonDTO(Person person) {
            PersonID = person.PersonID;
            BirthDay = person.BirthDay;
            FirstName = person.FirstName;
            MiddleName = person.MiddleName;
            LastName = person.LastName;

            
        }

        public static List<PersonDTO> ToListPersonDTO(List <Person> people) {
            List<PersonDTO> persons = new List<PersonDTO>();
            foreach (Person person in people) {
                persons.Add(new PersonDTO(person));
            }
            return persons;
        }
    }
}
