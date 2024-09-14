/// <summary>
/// ‘º‚ÌZ–¯
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
        if (!IsAlive)
        {
            return;
        }

        if (Job=="Farmer")
        {
            environment.Resources.Food += 10;
        }
        else if (Job == "Hunter")
        {
            environment.Resources.Food += 5;
        }

        Energy -= 10;
        Hunger += 10;

        if (Hunger>=100)
        {
            IsAlive = false;
            logManager.LogMessage($"{Name}‚Í‰ì€‚µ‚Ü‚µ‚½");
        }
    }
}