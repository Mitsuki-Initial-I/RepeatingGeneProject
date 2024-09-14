using UnityEditor;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    private Environment environment;
    private LogManager logManager;

    void Start()
    {
        logManager = new LogManager();
        environment = new Environment();

        Villager farmer = new Villager("John", 30, "Farmer");
        Villager hunter = new Villager("Jane", 25, "Hunter");

        environment.AddVillager(farmer);
        environment.AddVillager(hunter);

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
        this.enabled = false;
        EditorApplication.isPlaying = false;
    }
}