/// <summary>
/// ���̏Z��
/// </summary>

public class Villager
{
    public string Name { get; set; }
    public string Job { get; set; }
    public int Age { get; set; }
    public int Energy { get; set; }
    public int Hunger { get; set; }
    public bool IsAlive { get; private set; }

    public Villager(string name, int age , string job)
    {
        Name = name;
        Age = age;
        Job = job;
        Energy = 100;
        Hunger = 0;
        IsAlive = true;
    }

    public void Work(Environment environment, LogManager logManager)
    {
        if (!IsAlive || Energy<=0)
        {
            Rest();
            return;
        }

        switch (Job)
        {
            case "�_��":
                environment.Resources.Food += 1;
                break;
            case "�t":
                environment.Resources.Food += 1;
                break;
            case "��H":
                environment.Resources.Wood += 10;
                break;
            case "���t":
                environment.Resources.Food += 1;
                break;
            case "���":
                HealVillagers(environment, logManager);
                break;
            default:
                break;
        }

        Energy -= 20;
        Hunger += 15;

        if (Hunger>=100)
        {
            IsAlive = false;
            logManager.LogMessage($"{Name}�͉쎀���܂���");
        }
    }

    public void Rest()
    {
        Energy += 10;
        Hunger += 5;
    }
    public void Eat(Environment environment)
    {
        if (environment.Resources.Food>0)
        {
            environment.Resources.Food -= 1;
            Hunger -= 1;
            Energy += 10;
        }
    }
    private void HealVillagers(Environment environment,LogManager logManager)
    {
        foreach (var villager in environment.Villagers)
        {
            if (!villager.IsAlive&&villager.Hunger<50)
            {
                villager.IsAlive = true;
                logManager.LogMessage($"{villager.Name}�͎��Â���܂����B");
            }
        }
    }
}