using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angelina_ATM_Machine.DataAccess.Models;
using CRUDApps.DataAccess.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Angelina_ATM_Machine.DataAccess.Repositories
{
    public class ClientRepository
    {
        private Angelina_ATM_MachineContext _dbContext;

        public ClientRepository(Angelina_ATM_MachineContext dbContext)
        {
            _dbContext = dbContext;
        }


        public int Update(ClientModel clientData)
        {
            ClientModel existingClient = _dbContext.Client.Find(clientData.ClientId)!;

            existingClient.Balance = clientData.Balance;            

            _dbContext.SaveChanges();
            return existingClient.ClientId;
        }

        public List<ClientModel> GetAllClientModels()
        {
            return _dbContext.Client.ToList();
        }

        public ClientModel GetClientById(int clientId)
        {
            return _dbContext.Client.Find(clientId)!;
        }
        

        
    }
}
