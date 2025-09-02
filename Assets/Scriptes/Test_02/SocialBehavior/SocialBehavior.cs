using System;

public class SocialBehavior
{
    public void Interact(Creature predator, Creature prey)
    {
        if (predator.Energy < 20 && prey.IsAlive())
        {
            predator.Eat(prey);
            prey.Energy = 0;
            Console.WriteLine($"{predator.Name} hunted {prey.Name} and gained energy.");
        }
        else
        {
            Console.WriteLine($"{predator.Name} is not hungry or {prey.Name} is already dead.");
        }
    }
}