namespace Patterns.Builder
{
    public interface IBurgerBuilder
    {
        IBurgerBuilder AddBread();

        IBurgerBuilder AddTomato();

        IBurgerBuilder AddCheese();

        IBurgerBuilder AddSalad();

        IBurgerBuilder AddBeacon();

        IBurgerBuilder AddChicken();

        Burger GetBurger();
    }
}
