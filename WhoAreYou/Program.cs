using System;
using System.Collections.Generic;

namespace WhoAreYou
{
    internal class Program
    {

        public static List<User> users = new List<User>();

        static void Main(string[] args)
        {
            bool isAppRunning = true;
            while (isAppRunning)
            {
                Console.WriteLine("Welcome to the First Homework App!");
                Console.WriteLine(new string('-', 34));
                Console.WriteLine("1. Let's get started");
                Console.WriteLine("2. Exit");
                string menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        CollectUserData();
                        break;

                    case "2":
                        isAppRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid menu option. Please choose 1 or 2!");
                        break;
                }
            }
        }

        public class User
        {
            public string Name { get; set; }
            public DateTime Year { get; set; }
            public DateTime Month { get; set; }
            public DateTime Day { get; set; }
            public string BirthPlace { get; set; }

            public User(string name, DateTime year, DateTime month, DateTime day, string birthPlace)
            {
                Name = name;
                Year = year;
                Month = month;
                Day = day;
                BirthPlace = birthPlace;
            }
        }

        public static void CollectUserData()
        {
            Console.Clear();

            Console.WriteLine("Hi! What's your name?");
            string name = Console.ReadLine();

            Console.WriteLine("What year were you born?");
            int year = Convert.ToInt32(Console.ReadLine());

            if (year < 1910 || year > DateTime.Now.Year)
            {
                throw new Exception($"You entered an invalid birth year: {year}!");
            }

            Console.WriteLine("What month were you born?");
            int month = Convert.ToInt32(Console.ReadLine());

            if (month > 13 || month < 1)
            {
                throw new Exception("That's not a valid month! Please enter a number between 1 and 12.");
            }

            Console.WriteLine("What day were you born?");
            int day = Convert.ToInt32(Console.ReadLine());

            if (day > 31 || day < 1)
            {
                throw new Exception("That day doesn't exist! Please enter a number between 1 and 31.");
            }

            DateTime today = DateTime.Today;
            DateTime birthdayThisYear = new DateTime(today.Year, month, day);

            int age = today.Year - year;
            if (today < birthdayThisYear)
            {
                age--;
            }

            Console.WriteLine("What city were you born in?");
            string birthPlace = Console.ReadLine();

            var user = new User(name, new DateTime(year), new DateTime(month), new DateTime(day), birthPlace);
            users.Add(user);

            Console.WriteLine();
            Console.WriteLine($"Hey {name}, you were born in {birthPlace} and you are {age} years old.");
            Console.WriteLine($"Press any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}