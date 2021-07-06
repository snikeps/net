using System;
using System.Collections.Generic;
using System.Text;

namespace YieldKeyword
{
    public class Car
    {
        public string label { get; set; }
        public string color { get; set; }
        public int weight { get; set; }



        public Car(string label,string color, int weight)
        {
            this.label = label;
            this.color = color;
            this.weight = weight;
        }
    }
}
