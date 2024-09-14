using System;
using System.IO;

public class LogManager
{
    private string logFolderPath;

    public LogManager()
    {
        logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
        if (!Directory.Exists(logFolderPath))
        {
            Directory.CreateDirectory(logFolderPath);
        }
    }

    public void LogVillageState(Environment environment)
    {
        string filePath = Path.Combine(logFolderPath, $"VillageLog_{DateTime.Now:yyyyMMdd_HHmm}.txt");
        using (StreamWriter writer =new StreamWriter(filePath,true))
        {
            writer.WriteLine($"Day {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            writer.WriteLine($"Food: {environment.Resources.Food}");
            writer.WriteLine($"Wood: {environment.Resources.Wood}");
            writer.WriteLine($"Stone: {environment.Resources.Stone}");

            foreach (var villager in environment.Villagers)
            {
                writer.WriteLine($"Villager: {villager.Name}, Age: {villager.Age}, Job: {villager.Job}, Energy: {villager.Energy}, Hunger: {villager.Hunger}");
            }
            writer.WriteLine("----------------------------------------------------");
        }
    }
}