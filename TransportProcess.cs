using System;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    public class TransportProcess
    {
        public Tuple<int, string> RouteInformation(string onwardJourney)
        {
            var station = string.Empty;
            var order =0;
            var condition =false;
            Console.WriteLine();
            while(condition == false){
                var selection = Console.ReadLine();
                var currentMatches = AllStations.Where(i => i.Value.Contains(selection));
                if(currentMatches.Count() > 1){
                    Console.WriteLine();
                    Console.WriteLine("Please select one of the following {0}:", onwardJourney);
                     foreach(var eachMatch in currentMatches)
                     {
                        Console.WriteLine(eachMatch.Value);
                     }
                }
                else{
                    Console.WriteLine();
                    var currentObject = currentMatches.First();
                    if(currentMatches.Count() == 1){
                        station = currentMatches.First().Value;
                        order = currentMatches.First().Key;
                        Console.Write(station);
                        Console.Write(" is your chosen "+ onwardJourney);
                        Console.WriteLine();
                        condition = true;
                    }
                    else{
                        Console.WriteLine("Please enter a valid {0}.", onwardJourney);
                    }
                }
            }
            return new Tuple<int, string>(order,station);
        }

        public void DisplayStations(string condition = null) {
            Console.WriteLine();
            Console.WriteLine("Please select the station:");
            foreach(var i in AllStations.Where( m => m.Value != condition)){
                 Console.WriteLine(i.Value);
            }
        }

         public Dictionary<int, string> AllStations = new Dictionary<int, string>()
        {
            { 1, "Picadilly"},
            { 2, "Victoria"},
            { 3, "London Bridge"},
            { 4, "Greenwich"},
            { 5, "Paddington"}
        };


        public Mode InitialSelection() {
            Console.WriteLine("Please Enter your selection: 1) Train/Tube 2) Bus");
            var selection = Convert.ToInt32(Console.ReadLine());
            return (Mode)selection;
        }

        public void TicketPrice(Mode travelType, int originOrder, int destinationOrder)
        {
            Console.WriteLine();
            var difference = Math.Abs(originOrder - destinationOrder);
            switch(travelType){
                case Mode.Train:
                case Mode.Tube:
                    var railFare = Constants.TrainAndTubeFare * difference;
                    Console.WriteLine("Your fare is: £{0}", railFare);
                    break;
                case Mode.Bus:
                    var busFare = Constants.BusFare * difference;
                    Console.WriteLine("Your fare is: £{0}", busFare);
                    break;
                default:
                    Console.WriteLine("Please try again.");
                    break;
            }
        }

        public void PrintTicket(string origin, string destination){
            Console.WriteLine("Your booking has been processed");
            Console.WriteLine("Your ticket: {0} --> {1}", origin, destination);
        }

    }
    
}