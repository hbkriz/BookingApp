using System;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    class Program
    {

        static void Main(string[] args)
        {
            var _transportProcess= new TransportProcess();
            var modeSelection = _transportProcess.InitialSelection();
            _transportProcess.DisplayStations();
            var origin =_transportProcess.RouteInformation("Origin");
            _transportProcess.DisplayStations(origin.Item2);
            var destination =_transportProcess.RouteInformation("Destination");
            _transportProcess.TicketPrice(modeSelection, origin.Item1, destination.Item1);
            _transportProcess.PrintTicket(origin.Item2, destination.Item2);
        }
    }
    
}
