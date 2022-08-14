using Patterns.Builder;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var burgerBuilder = new BurgerBuilder()
                .AddChicken()
                .AddCheese()
                .AddSalad()
                .AddBread();

            System.Console.WriteLine(burgerBuilder.GetBurger());
        }
    }
}