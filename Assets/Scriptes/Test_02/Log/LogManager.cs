using UnityEngine;
using System.IO;

public class LogManger
{
    private string logFilePath;

    // コンストラクタで初期化
    public LogManger()
    {
        // ログフォルダを作成
        string logDirectory = Application.dataPath + "/Logs";
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }

        // ログファイル名を作成
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        logFilePath = logDirectory + "/simulation_log_" + timestamp + ".txt";

        // ログファイルを初期化
        InitializeLogFile();
    }

    // ログファイルを初期化
    private void InitializeLogFile()
    {
        using (StreamWriter writer=new StreamWriter(logFilePath,false))
        {
            writer.WriteLine("Simulation Log Started");
            writer.WriteLine("======================");
        }
    }

    // ログを記録するメソッド
    public void Log(string message)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine(System.DateTime.Now + ":" + message);
        }
    }

    // 情報を記録するメソッド
    public void LogEnvironmmentState(Environment environment)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine("\nDay Simulation Log:");
            writer.WriteLine("Resources:"+environment.ResourceAmount);
            writer.WriteLine($"Day: {environment.SimulationDays}");
            if (environment.IsError)
            {
                writer.WriteLine($"Error: 問題発生　\n{environment.ErrorStr}");
            }
            foreach (var creature in environment.Creatures)
            {
                writer.WriteLine($"{creature.Name}: Age = {creature.Age}, Energy = {creature.Energy}, Hunger = {creature.Hunger}");
            }
        }
    }
}