using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLayer.Interfaces
{
    public interface ILibraryCardsRepository
    {




        public IEnumerable<string> AllRefund();

        public IEnumerable<string> AllRefundPerson(int personID);

        public string ChangeRefund(int bookID, int userID, int days);


        public void save();

        

    }
}
