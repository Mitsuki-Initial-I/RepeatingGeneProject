
using System.Collections.Generic;
/// <summary>
/// ŠÂ‹«
/// </summary>
public class Environment
{
    public VillageResource Resources { get; private set; }
    public List<Villager> Villagers { get; private set; }

    public Environment()
    {
        Resources = new VillageResource(100, 50, 30);
        Villagers = new List<Villager>();
    }

    public void AddVillager(Villager villager)
    {
        Villagers.Add(villager);
    }

    public void SimulateDay(LogManager logManager)
    {
        foreach (var villager in Villagers)
        {
            villager.Work(this);
            Resources.ConsumeResources(villager);
        }

        logManager.LogVillageState(this);
    }
}