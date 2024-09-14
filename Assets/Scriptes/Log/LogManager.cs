using System;
using System.IO;
using UnityEngine;

public class LogManager
{
    private string logFolderPath;

    public LogManager()
    {
        // ログフォルダ
        string logDirectory = Application.dataPath + "/Logs/";
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }

        // ログファイル
        string baseFileName = "simulateion_log.txt";
        logFolderPath = logDirectory + GetUniqueFileName(logDirectory, baseFileName);
        Debug.Log(logFolderPath);
        // 初期化
        InitializeLogFile();
    }
    string GetUniqueFileName(string directorPath, string baseFileName)
    {
        string extension = Path.GetExtension(baseFileName);
        string fileNameWithouExtension = Path.GetFileNameWithoutExtension(baseFileName);

        string datePart = DateTime.Now.ToString("yyyy-MM-dd");
        int counter = 0;
        string newFileName = $"{fileNameWithouExtension}_{datePart}{extension}";

        while (File.Exists(Path.Combine(directorPath, newFileName)))
        {
            counter++;
            newFileName = $"{fileNameWithouExtension}_{datePart}-{counter}{extension}";
        }

        return newFileName;
    }

    private void InitializeLogFile()
    {
        using (StreamWriter writer = new StreamWriter(logFolderPath, false))
        {
            writer.WriteLine("Simulation Log Started.");
            writer.WriteLine("======================");
        }
    }

    public void LogVillageState(Environment environment)
    {
        using (StreamWriter writer = new StreamWriter(logFolderPath, true))
        {
            writer.WriteLine($"日数: {environment.SimulationDays}");
            writer.WriteLine($"LogTime: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            writer.WriteLine($"食料: {environment.Resources.Food}");
            writer.WriteLine($"木材: {environment.Resources.Wood}");
            writer.WriteLine($"石材: {environment.Resources.Stone}");

            if (environment.IsAbandoned)
            {
                writer.WriteLine("村は放棄されました");
            }
            else
            {
                foreach (var villager in environment.Villagers)
                {
                    writer.WriteLine($"Villager: {villager.Name}, Age: {villager.Age}, Job: {villager.Job}, Energy: {villager.Energy}, Hunger: {villager.Hunger}");
                }
            }
            writer.WriteLine("----------------------------------------------------");
        }
    }

    public void LogMessageStart(string message)
    {
        using (StreamWriter writer = new StreamWriter(logFolderPath, true))
        {
            writer.WriteLine($"Day {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            writer.WriteLine(message);
            writer.WriteLine("----------------------------------------------------");
        }
    }
    public void LogMessage(string message)
    {
        using (StreamWriter writer = new StreamWriter(logFolderPath, true))
        {
            writer.WriteLine(message);
        }
    }
}