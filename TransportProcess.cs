using System;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    public class TransportProcess
    {
        public string _station;
        public int _order;
        public bool _condition;
        public string _onwardJourney;
        public void Initialise(string onwardJourney) {
            _station = string.Empty;
            _onwardJourney = onwardJourney;
            _order = Constants.StationNumber;
            _condition=Constants.FalseCondition;
        }

        public Mode InitialSelection() {
            Console.WriteLine("Please Enter your selection: 1) Train/Tube 2) Bus");
            var selection = Convert.ToInt32(Console.ReadLine());
            return (Mode)selection;
        }

        public void DisplayStations(string condition = null) {
            Console.WriteLine();
            Console.WriteLine("Please select the station:");
            foreach(var i in AllStations.Where( m => m.Value != condition)){
                 Console.WriteLine(i.Value);
            }
        }

        public Tuple<int, string> RouteInformation()
        {
            while(_condition == Constants.FalseCondition){
                Console.WriteLine();
                var selection = Console.ReadLine();
                var currentMatches = AllStations.Where(i => i.Value.Contains(selection));
                LogicToDisplay(currentMatches);
            }
            return new Tuple<int, string>(_order,_station);
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

        private void LogicToDisplay(IEnumerable<KeyValuePair<int, string>> currentMatches)
        {
            if(currentMatches.Count() > 1) {
                Console.WriteLine("Please select one of the following {0}s:", _onwardJourney);
                    foreach(var eachMatch in currentMatches)
                    {
                    Console.WriteLine(eachMatch.Value);
                    }
            }
            else if(currentMatches.Count() == 1) {
                    _station = currentMatches.First().Value;
                    _order = currentMatches.First().Key;
                    Console.WriteLine("{0} is your chosen {1}", _station, _onwardJourney);
                    _condition = Constants.TrueCondition;
            }
            else {
                    Console.WriteLine("Please enter a valid {0}.", _onwardJourney);
            }
        } 

        private Dictionary<int, string> AllStations = new Dictionary<int, string>()
        {
            { 1, "Picadilly"},
            { 2, "Victoria"},
            { 3, "London Bridge"},
            { 4, "Greenwich"},
            { 5, "Paddington"}
        };

    }
    
}