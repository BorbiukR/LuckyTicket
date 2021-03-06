using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LuckyTicket
{
    public class Program
    {
        private static readonly Dictionary<ConsoleKey, string> CommandsNames = new Dictionary<ConsoleKey, string>
        {
            {ConsoleKey.P, "Play"},
            {ConsoleKey.E, "Exit"},
        };

        public static void Main()
        {
            SayHello();

            while (true)
            {
                ShowAllCommands();

                var continueProcess = ReadUserCommand();
                if (!continueProcess)
                {
                    break;
                }
            }

            SayBye();
        }

        private static void SayHello()=>
            Console.WriteLine("Hi, this is a console application - Lucky ticket");

        private static void SayBye() =>
            Console.WriteLine("See you again!");

        private static void ShowAllCommands()
        {
            foreach (var key in CommandsNames.Keys)
                Console.WriteLine($"{key} - {CommandsNames[key]}");
        }

        private static bool ReadUserCommand()
        {
            var command = Console.ReadKey().Key;
            switch (command)
            {
                case ConsoleKey.P:
                    Play();
                    return true;
                case ConsoleKey.E:
                    return false;
                default:
                    Console.WriteLine("Invalid key");
                    return true;
            }
        }

        private static void Play()
        {
            var ticketNumber = TryGetTicketNumber();
            var formattedTicketNumber = GetFormattedTicketNumber(ticketNumber);

            IsTicketLucky(formattedTicketNumber);
        }

        private static string TryGetTicketNumber()
        {
            string value;

            while (true)
            {
                Console.WriteLine("Enter a number from 4 to 8 digits");

                value = Console.ReadLine();
                if (IsTicketNumberValid(value))
                {
                    break;
                }

                Console.WriteLine("Not the correct number format");
            }

            return value;
        }

        private static bool IsTicketNumberValid(string ticketNumber) =>
            !string.IsNullOrWhiteSpace(ticketNumber)
            && ticketNumber.Length >= 4
            && ticketNumber.Length <= 8
            && Regex.IsMatch(ticketNumber, "^[0-9]+$");

        private static string GetFormattedTicketNumber(string ticketNumber) =>
            ticketNumber.Length % 2 == 0
                ? ticketNumber
                : "0" + ticketNumber;

        private static void IsTicketLucky(string enteredNumber)
        {
            var halfLength = enteredNumber.Length / 2;

            var firstHalf = enteredNumber.Substring(0, halfLength);
            var secondHalf = enteredNumber.Substring(halfLength, halfLength);

            Console.WriteLine(GetDigitsSum(firstHalf) == GetDigitsSum(secondHalf)
                ? "Congratulations, your ticket is lucky. Play again or leave:"
                : "Your ticket is unlucky. Play again or leave:");
        }

        private static int GetDigitsSum(string value) => value
            .Where(char.IsNumber)
            .Sum(x => Convert.ToInt32(x.ToString()));
    }
}