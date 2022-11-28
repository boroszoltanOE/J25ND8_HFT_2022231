using ConsoleTools;
using J25ND8_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace J25ND8_HFT_2022231.Client
{
    static class Extension
    {
        public static void ToConsole<T>(this IEnumerable<T> input, string str)
        {
            Console.WriteLine($"******** BEGIN - {str} ********\n");
            int counter = 1;
            foreach (T item in input)
            {
                Console.WriteLine($"\t{counter++}.\t-\t"+ item.ToString());
            }
            Console.WriteLine($"\n******** END - {str} ********");
        }
    }
    public class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Passenger")
            {
                Console.Write("Enter Passenger Name: ");
                string name = Console.ReadLine();
                rest.Post(new Passenger() { Name = name }, "passenger");
            }
            else if (entity == "Airline")
            {
                Console.Write("Enter Airline Name: ");
                string name = Console.ReadLine();
                rest.Post(new Airline() { Name = name }, "airline");
            }
            else
            {
                Console.Write("Enter Plane Name: ");
                string name = Console.ReadLine();
                rest.Post(new Plane() { Type = name }, "plane");
            }
        }
        static void Read(string entity)
        {
            if (entity == "Passenger")
            {
                Console.Write("Enter Passenger's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Passenger one = rest.Get<Passenger>(id, "passenger");
                Console.WriteLine($"{one.Id} : {one.Name}, ticket price: {one.TicketPrice}");
            }
            else if (entity == "Airline")
            {
                Console.Write("Enter Airline's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Airline one = rest.Get<Airline>(id, "airline");
                Console.WriteLine($"{one.Id} : {one.Name}");
            }
            else
            {
                Console.Write("Enter Plane's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Plane one = rest.Get<Plane>(id, "plane");
                Console.WriteLine($"{one.Id} : {one.Type}");
            }
            Console.ReadLine();
        }
        static void ReadAll(string entity)
        {
            if (entity == "Passenger")
            {
                List<Passenger> passengers = rest.Get<Passenger>("Passenger");
                foreach (var item in passengers)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            else if (entity=="Airline")
            {
                List<Airline> airlines = rest.Get<Airline>("Airline");
                foreach (var item in airlines)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            else
            {
                List<Plane> planes = rest.Get<Plane>("Plane");
                foreach (var item in planes)
                {
                    Console.WriteLine(item.Id + ": " + item.Type);
                }
            }
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            if (entity == "Passenger")
            {
                Console.Write("Enter Passenger's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "passenger");
            }
            else if (entity == "Airline")
            {
                Console.Write("Enter Airline's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "airline");
            }
            else
            {
                Console.Write("Enter Plane's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "plane");
            }
        }
        static void Update(string entity)
        {
            if (entity == "Passenger")
            {
                Console.Write("Enter Passenger's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Passenger one = rest.Get<Passenger>(id, "passenger");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "passenger");
            }
            else if (entity == "Airline")
            {
                Console.Write("Enter Airline's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Airline one = rest.Get<Airline>(id, "airline");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "airline");
            }
            else
            {
                Console.Write("Enter Plane's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Plane one = rest.Get<Plane>(id, "plane");
                Console.Write($"New name [old: {one.Type}]: ");
                string name = Console.ReadLine();
                one.Type = name;
                rest.Put(one, "plane");
            }
        }
        static void NoncrudHandler(string action)
        {
            if (action == "AirlinesMostExpensiveTickets")
            {
                var tmp = rest.Get<KeyValuePair<string,int>>($"Stat/{action}");
                tmp.AsEnumerable().ToConsole("AirlinesMostExpensiveTickets");
                
            }
            else if (action == "AVGTicketPricesPerAirlines")
            {
                var tmp = rest.Get<KeyValuePair<string, double>>($"Stat/{action}");
                tmp.AsEnumerable().ToConsole("AVGTicketPricesPerAirlines");
            }
            else if (action == "CountOfSoldFirstClassTicketsPerAirlines")
            {
                var tmp = rest.Get<KeyValuePair<string, int>>($"Stat/{action}");
                tmp.AsEnumerable().ToConsole("CountOfSoldFirstClassTicketsPerAirlines");
            }
            else if (action == "PlanesWithSafeAirlines")
            {
                var tmp = rest.Get<KeyValuePair<string, double>>($"Stat/{action}");
                tmp.AsEnumerable().ToConsole("PlanesWithSafeAirlines");
            }
            else
            {
                var tmp = rest.Get<KeyValuePair<string, double>>($"Stat/{action}");
                tmp.AsEnumerable().ToConsole("LongestTravelsPerAirlines");
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:34836/");

            var statMenu = new ConsoleMenu(args, level: 1)
                .Add("AirlinesMostExpensiveTickets", () => NoncrudHandler("AirlinesMostExpensiveTickets"))
                .Add("AVGTicketPricesPerAirlines", () => NoncrudHandler("AVGTicketPricesPerAirlines"))
                .Add("CountOfSoldFirstClassTicketsPerAirlines", () => NoncrudHandler("CountOfSoldFirstClassTicketsPerAirlines"))
                .Add("PlanesWithSafeAirlines", () => NoncrudHandler("PlanesWithSafeAirlines"))
                .Add("LongestTravelsPerAirlines", () => NoncrudHandler("LongestTravelsPerAirlines"))
                .Add("Exit", ConsoleMenu.Close);

            var passengerMenu = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => ReadAll("Passenger"))
                .Add("Read", () => Read("Passenger"))
                .Add("Create", () => Create("Passenger"))
                .Add("Delete", () => Delete("Passenger"))
                .Add("Update", () => Update("Passenger"))
                .Add("Exit", ConsoleMenu.Close);

            var planeMenu = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => ReadAll("Plane"))
                .Add("Read", () => Read("Plane"))
                .Add("Create", () => Create("Plane"))
                .Add("Delete", () => Delete("Plane"))
                .Add("Update", () => Update("Plane"))
                .Add("Exit", ConsoleMenu.Close);

            var airlineMenu = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => ReadAll("Airline"))
                .Add("Read", () => Read("Airline"))
                .Add("Create", () => Create("Airline"))
                .Add("Delete", () => Delete("Airline"))
                .Add("Update", () => Update("Airline"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Passengers", () => passengerMenu.Show())
                .Add("Planes", () => planeMenu.Show())
                .Add("Airlines", () => airlineMenu.Show())
                .Add("Noncruds", () => statMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
