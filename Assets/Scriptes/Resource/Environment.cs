
using System.Collections.Generic;
/// <summary>
/// ��
/// </summary>
public class Environment
{
    // ���̃��\�[�X
    public VillageResource Resources { get; private set; }
    // ���l���
    public List<Villager> Villagers { get; private set; }
    // ���̏��
    public bool IsAbandoned { get; private set; }

    // �V�~�����[�V��������
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
            logManager.LogMessageStart("�V�~�����[�g�I���ɓ����ƂȂ�܂���");
            return;
        }

        if (IsAbandoned)
        {
            logManager.LogMessageStart("���͔p���ƂȂ�܂���");
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
            logManager.LogMessage("���͑����ł��܂���");
        }
    }
    
}