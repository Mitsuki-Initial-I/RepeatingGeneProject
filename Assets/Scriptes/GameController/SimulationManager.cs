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

        Villager villager1 = new Villager("John", 30, "農家");
       // Villager villager2 = new Villager("Jane", 25, "猟師");
       // Villager villager3 = new Villager("Jane", 25, "漁師");
        Villager villager4 = new Villager("Jane", 25, "大工");
        Villager villager5 = new Villager("Jane", 25, "大工");
        Villager villager6 = new Villager("Jane", 25, "大工");
        Villager villager7 = new Villager("Jane", 25, "医者");

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
            logManager.LogMessage("村が放棄されたため、シミュレートを終了します");
            EndSimulate();
        }
        else if (environment.SimulationDays>=environment.MaxSimulationDays)
        {
            logManager.LogMessage("シミュレート終了日時となった為、シミュレートを終了します。");
            EndSimulate();
        }

        if (Time.frameCount % 10 == 0)
        {
            environment.SimulateDay(logManager);
        }
    }
    private void EndSimulate()
    {
        logManager.LogMessage("シミュレーションは停止しました。");
        Debug.Log("シミュレーションは停止しました。");
        this.enabled = false;
        EditorApplication.isPlaying = false;
    }
}