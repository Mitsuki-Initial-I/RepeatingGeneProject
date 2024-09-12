using UnityEngine;
using System.IO;

public class LogManger
{
    private string logFilePath;

    // �R���X�g���N�^�ŏ�����
    public LogManger()
    {
        // ���O�t�H���_���쐬
        string logDirectory = Application.dataPath + "/Logs";
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }

        // ���O�t�@�C�������쐬
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        logFilePath = logDirectory + "/simulation_log_" + timestamp + ".txt";

        // ���O�t�@�C����������
        InitializeLogFile();
    }

    // ���O�t�@�C����������
    private void InitializeLogFile()
    {
        using (StreamWriter writer=new StreamWriter(logFilePath,false))
        {
            writer.WriteLine("Simulation Log Started");
            writer.WriteLine("======================");
        }
    }

    // ���O���L�^���郁�\�b�h
    public void Log(string message)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine(System.DateTime.Now + ":" + message);
        }
    }

    // �����L�^���郁�\�b�h
    public void LogEnvironmmentState(Environment environment)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine("\nDay Simulation Log:");
            writer.WriteLine("Resources:"+environment.ResourceAmount);
            writer.WriteLine($"Day: {environment.SimulationDays}");
            if (environment.IsError)
            {
                writer.WriteLine($"Error: ��蔭���@\n{environment.ErrorStr}");
            }
            foreach (var creature in environment.Creatures)
            {
                writer.WriteLine($"{creature.Name}: Age = {creature.Age}, Energy = {creature.Energy}, Hunger = {creature.Hunger}");
            }
        }
    }
}