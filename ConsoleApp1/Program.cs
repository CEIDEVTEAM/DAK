using BusinessLogic.Logic;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            LDeliveryAreaController da = new LDeliveryAreaController();
            List<DeliveryAreaDto> dto = da.GetAllAreas();
            Console.WriteLine("Hello World!");
        }
    }
}
