namespace Patterns.Builder
{
    public class BurgerBuilder : IBurgerBuilder
    {
        private Burger _burger = new();

        public IBurgerBuilder AddBeacon()
        {
            _burger.Filling += "Beacon\n";
            return this;
        }

        public IBurgerBuilder AddBread()
        {
            _burger.Top = _burger.Bottom = "Bread\n";
            return this;
        }

        public IBurgerBuilder AddCheese()
        {
            _burger.Filling += "Cheese\n";
            return this;
        }

        public IBurgerBuilder AddChicken()
        {
            _burger.Filling += "Chicken\n";
            return this;
        }

        public IBurgerBuilder AddSalad()
        {
            _burger.Filling += "Salad\n";
            return this;
        }

        public IBurgerBuilder AddTomato()
        {
            _burger.Filling += "Tomato\n";
            return this;
        }

        public Burger GetBurger()
        {
            Burger burger = _burger;

            _burger = new();

            return burger;
        }
    }
}
