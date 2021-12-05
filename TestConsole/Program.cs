using BusinessLogic.DataModel;
using BusinessLogic.DataModel.Repository;
using BusinessLogic.Logic;
using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork lcc = new UnitOfWork();

            List<Client> testList = lcc.FinalClientRepository.GetAllClient();

            
        }
    }
}
