using UnityEditor;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    private Environment environment;
    private LogManager logManager;

    void Start()
    {
        logManager = new LogManager();
        environment = new Environment(0);

        Villager villager1 = new Villager("John", 30, "�_��");
       // Villager villager2 = new Villager("Jane", 25, "�t");
       // Villager villager3 = new Villager("Jane", 25, "���t");
        Villager villager4 = new Villager("Jane", 25, "��H");
        Villager villager5 = new Villager("Jane", 25, "��H");
        Villager villager6 = new Villager("Jane", 25, "��H");
        Villager villager7 = new Villager("Jane", 25, "���");

        environment.AddVillager(villager1);
        //environment.AddVillager(villager2);
        //environment.AddVillager(villager3);
        environment.AddVillager(villager4);
        environment.AddVillager(villager5);
        environment.AddVillager(villager6);
        environment.AddVillager(villager7);

        logManager.LogVillageState(environment);
    }

    void Update()
    {
        if (environment.IsAbandoned)
        {
            logManager.LogMessage("�����������ꂽ���߁A�V�~�����[�g���I�����܂�");
            EndSimulate();
        }
        else if (environment.SimulationDays>=environment.MaxSimulationDays)
        {
            logManager.LogMessage("�V�~�����[�g�I�������ƂȂ����ׁA�V�~�����[�g���I�����܂��B");
            EndSimulate();
        }

        if (Time.frameCount % 10 == 0)
        {
            environment.SimulateDay(logManager);
        }
    }
    private void EndSimulate()
    {
        logManager.LogMessage("�V�~�����[�V�����͒�~���܂����B");
        Debug.Log("�V�~�����[�V�����͒�~���܂����B");
        this.enabled = false;
        EditorApplication.isPlaying = false;
    }
}