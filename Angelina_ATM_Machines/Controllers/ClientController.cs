using Angelina_ATM_Machine.DataAccess.Models;
using Angelina_ATM_Machine.DataAccess.Repositories;
using Angelina_ATM_Machine.Models;
using CRUDApps.DataAccess.EF.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Angelina_ATM_Machine.Controllers
{
    public class ClientController : Controller
    {
        public ClientRepository _repo;
        public ClientController(ClientRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Deposit()
        {
            return View();
        }

        public IActionResult DepositAmount(ClientViewModel model)
        {
            model.ClientId = 1;
            var clientExists = _repo.GetClientById(model.ClientId);
            if (clientExists is not null)
            {
                var currentBalance = clientExists.Balance;
                var depositAmount = model.AmountToChange;
                var newBalance = currentBalance + depositAmount;
                model.Balance += depositAmount;
                var clientToUpdate = new ClientModel
                {
                    ClientId = model.ClientId,
                    Balance = newBalance
                };
                model.Balance = clientToUpdate.Balance;
                _repo.Update(clientToUpdate);
            }

            return View("DepositComplete", model);
        }

        public IActionResult WithdrawAmount(ClientViewModel model)
        {
            model.ClientId = 1;
            var clientExists = _repo.GetClientById(model.ClientId);
            if (clientExists is not null)
            {
                var currentBalance = clientExists.Balance;
                var withdrawAmount = model.AmountToChange;
                var newBalance = currentBalance - withdrawAmount;
                model.Balance -= withdrawAmount;
                var clientToUpdate = new ClientModel
                {
                    ClientId = model.ClientId,
                    Balance = newBalance
                };
                model.Balance = clientToUpdate.Balance;
                _repo.Update(clientToUpdate);
            }

            return View("DepositComplete", model);
        }

        public IActionResult CheckBalance(ClientViewModel balanceModel)
        {
            balanceModel.ClientId = 1;

            var clientExists = _repo.GetClientById(balanceModel.ClientId);
            if (clientExists is not null)
            {
                balanceModel.Balance = clientExists.Balance;
            }

            return View("CheckBalance", balanceModel);
        }

        public IActionResult Main()
        {
            return View();
        }
        public IActionResult Withdraw()
        {
            return View();
        }

        public IActionResult TransationComplete()
        {
            ClientViewModel model = new ClientViewModel();
            return View(model);
        }
      
        
        public IActionResult verifyPassword(string pass)
        {
            if (pass != "123435")
            {
                ClientViewModel model = new ClientViewModel();
                model.IsActionSuccess = false;
                model.ActionMessage = "Ay Dios mio! You entered the incorrect password! Please try again!";
            }

            return Redirect("Main");

        }


    }
}
