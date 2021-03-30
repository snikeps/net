using System;
using System.Collections.Generic;
using System.Text;

namespace DictSnippets
{
    class Country
    {
        public string Name;
        public string Code;
        public string Location;
        public int Population;

        public Country (string name,string code, string location, int population)
        {
            this.Name = name;
            this.Code = code;
            this.Location = location;
            this.Population = population;
        }

    }
}
