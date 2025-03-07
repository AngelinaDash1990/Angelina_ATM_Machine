﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angelina_ATM_Machine.DataAccess.Models
{
    public class ClientModel
    {
        public int ClientId { get; set; }
        public string AccountHolder { get; set; }
        public int AccountNumber { get; set; }
        [Required(ErrorMessage = "Yo dawg, you gotta enter a value! 🤑")]
        public decimal Balance { get; set; }

        public ClientModel(int clientId, int accountNumber, string accountHolder, decimal balance)
        {
            ClientId = clientId;
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = balance;
        }
        public ClientModel()
        {

        }
    }
    
}
