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

    public Villager(string name, int age , string job)
    {
        Name = name;
        Age = age;
        Job = job;
        Energy = 100;
        Hunger = 0;
    }

    public void Work(Environment environment)
    {
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
    }
}