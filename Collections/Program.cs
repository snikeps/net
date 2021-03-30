using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\yusupova\Documents\PluralSight\Collections\csharp-collections-beginning\Pop.csv";

            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadAllCountries();
            reader.RemoveCommaCounties(countries);


            var filteredCountries = countries.Where(x => !x.Name.Contains(','));//.Take(20);
            var filteredCpuntries2 = from country in countries
                                     where !country.Name.Contains(',')
                                     select country;

            foreach (Country country in filteredCountries)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }


            //Country lilliput = new Country("Lilliput", "LIL", "somewhere", 2_000_000);
            //int lilliputIndex = countries.FindIndex(x => x.Population < 2_000_000);
            //countries.Insert(lilliputIndex, lilliput);
            //countries.RemoveAt(lilliputIndex);

            //Console.Write("Enter no. of contries to display > ");
            //bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
            //if(!inputIsInt || userInput <= 0)
            //{
            //    Console.WriteLine("You must tyoe in a +ve integer. Exsting");
            //    return;
            //}

            //int maxToDisplay = userInput;
            //foreach (Country country in countries)
            //for (int i = 0; i < countries.Count; i++)
            //{
            //    if(i>0 && (i % maxToDisplay == 0))
            //    {
            //        Console.WriteLine("Hit return to continue, anything else to quit>");
            //        if (Console.ReadLine() != "")
            //            break;
            //    }

            //    Country country = countries[i];
            //    Console.WriteLine($"{i + 1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            //}

            //Console.WriteLine($"Total amount of counties: {countries.Count}");

            //Dictionary<string, Country> countries = reader.ReadAllCountries();

            //Console.WriteLine("Which counrty code do you want to look up? ");
            //string userInput = Console.ReadLine().ToUpper();

            //bool gotCountry = countries.TryGetValue(userInput, out Country country);
            //if (!gotCountry)
            //    Console.WriteLine($"Sorry, there is no country with code {userInput}");
            //else
            //    Console.WriteLine($"{country.Name} has population " +
            //        $"{PopulationFormatter.FormatPopulation(country.Population)}");

        }
    }
}
