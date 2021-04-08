namespace BuisnessLayer.Interfaces
{
    public interface ILibraryCardsRepository
    {
        public string AllRefund();
        public string AllRefundPerson(int personID);
        public string ChangeRefund(int bookID, int userID, int days);
        public void Save();
    }
}
