using System;

namespace ClassLibrary1
{
    public static class Class1
    {
        public static double SCircle(double r)
        {
            return Math.PI * r * r;
        }

        public static float STriangle(float a, float b, float c)
        {
            float p = (a + b + c) / 2;
            try
            {
                return (float)Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            catch
            {
                throw new Exception("Input values should be greater than zero");
            }
        }
    }
}
