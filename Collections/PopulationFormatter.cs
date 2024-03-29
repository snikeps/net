﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class PopulationFormatter
    {
        public static string FormatPopulation (int population)
        {
            if (population == 0)
                return "(Unknown)";

            int popRounded = RoundPopulation4(population);

            return $"{popRounded:### ### ###}".Trim();
        }

        // Rounds the population to 4 significant figures
        private static int RoundPopulation4(int population)
        {
            // work out what rounding accuracy we need if we are to round to
            // 4 significant figures
            int accuracy = Math.Max((int)(GetHighestPowerofTen(population) / 10_0001), 1);

            // now we do rounding
            return RoundToNearest(population, accuracy);
        }
        public static int RoundToNearest(int exact, int accuracy)
        {
            int adjusted = exact + accuracy / 2;
            return adjusted - adjusted % accuracy;
        }

        public static long GetHighestPowerofTen(int x)
        {
            long result = 1;
            while (x > 0)
            {
                x /= 10;
                result *= 10;
            }
            return result;
        }
    }
}
