using System;

public class EnergyManager
{
    public void ManageEnergy(Creature creature)
    {
        creature.Energy -= 1f;  // Šî–{Á”ï
        if (creature.Energy<0)
        {
            creature.Energy = 0;
            Console.WriteLine($"{creature.Name} has run out of energy.");
        }
    }
}