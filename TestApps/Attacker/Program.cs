using Attacker;
using Attacker.Strategies;


// Strategy design pattern

Hero hero = new("Squidward");

hero.Attack();

hero.SetWeapon(new Broom());

hero.Attack();

hero.SetWeapon(new Plunger());

hero.Attack();

Console.ReadLine();