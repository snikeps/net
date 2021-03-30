using System;
using System.Collections.Generic;

namespace DictSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            Country norway = new Country("Norway", "NOR", "Europe", 5_282_223);
            Country finland = new Country("Finland", "FIN", "Europe", 5_511_303);

            var countries = new Dictionary<string, Country>
            {
                { norway.Code, norway },
                { finland.Code, finland }
            };

            //Console.WriteLine(countries["MUS"].Name);
            bool isExist = countries.TryGetValue("MUS", out Country country);

            if (isExist)
                Console.WriteLine(country.Name);
            else
                Console.WriteLine("There is no such country");


            //Country selectedCountry = countries["NOR"];
            //Console.WriteLine($"Selected country is: {selectedCountry.Name}");

            //foreach (var country in countries.Values)
            //{
            //    Console.WriteLine(country.Name);
            //}

        }
    }
}
