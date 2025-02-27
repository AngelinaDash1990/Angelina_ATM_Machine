using Angelina_ATM_Machine.DataAccess.Models;

namespace Angelina_ATM_Machine.Models
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }
        public ClientModel CurrentClient { get; set; }
        public decimal AmountToChange { get; set; }
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public string ActionMessage { get; set; }
        public bool IsActionSuccess { get; set; }
    }
}
