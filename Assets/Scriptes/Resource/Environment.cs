
using System.Collections.Generic;
/// <summary>
/// 環境
/// </summary>
public class Environment
{
    // 村のリソース
    public VillageResource Resources { get; private set; }
    // 村人情報
    public List<Villager> Villagers { get; private set; }
    // 村の状態
    public bool IsAbandoned { get; private set; }

    // シミュレーション時間
    public int SimulationDays { get; private set; }
    public int MaxSimulationDays { get; private set; }

    public Environment(int maxSimulationDays=100)
    {
        Resources = new VillageResource(100, 50, 30);
        Villagers = new List<Villager>();
        SimulationDays = 0;
        MaxSimulationDays = maxSimulationDays;
        IsAbandoned = false;
    }

    public void AddVillager(Villager villager)
    {
        Villagers.Add(villager);
    }

    public void SimulateDay(LogManager logManager)
    {
        if (SimulationDays>=MaxSimulationDays)
        {
            logManager.LogMessageStart("シミュレート終了に日時となりました");
            return;
        }

        if (IsAbandoned)
        {
            logManager.LogMessageStart("村は廃村となりました");
            return;
        }

        foreach (var villager in Villagers)
        {
            villager.Work(this, logManager);
            Resources.ConsumeResources(villager);
        }

        CheckForAbandonment(logManager);

        SimulationDays++;
        logManager.LogVillageState(this);
    }

    private void CheckForAbandonment(LogManager logManager)
    {
        foreach (var villager in Villagers)
        {
            if (!villager.IsAlive)
            {
                Villagers.Remove(villager);
            }
        }
        if (Resources.Food <= 0 || Villagers.Count == 0)
        {
            IsAbandoned = true;
            logManager.LogMessage("村は存続できません");
        }
    }
    
}