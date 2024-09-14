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
        if (Time.frameCount % 60 == 0)
        {
            environment.SimulateDay(logManager);
        }
    }
}