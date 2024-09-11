using System;

/// <summary>
/// 環境シミュレーション
/// </summary>
public class Environment 
{
    public float temperature;               // 気温
    public float humidity;                  // 湿度
    public float resourceAbundance;         // 資源の豊富さ
    public bool isDayTime;                  // 昼夜サイクル

    public TerrainType terrain;             // 地形
    public WeatherType weather;             // 天候

    private float dayNightCycleDuration;
    private float cycleTimer;

    public Environment()
    {
        temperature = 20f;
        humidity = 50f;
        resourceAbundance = 1f;
        isDayTime = true;

        terrain = TerrainType.Forest;
        weather = WeatherType.Sunny;

        dayNightCycleDuration = 60f;
        cycleTimer = 0f;
    }
        

    public void Update(float deltaTime)
    {
        // 昼夜サイクルの処理
        cycleTimer += deltaTime;
        if (cycleTimer >= dayNightCycleDuration)
        {
            isDayTime = !isDayTime;
            cycleTimer = 0f;
            //Console.WriteLine(isDayTime ? "It's now daytime." : "It's now nighttime.");
        }

        // 天候や気温、湿度がランダムに変化
        SimulateEnvironment();

        // 環境内の資源が時間と共に変化する
        resourceAbundance -= deltaTime * 0.01f;
        if (resourceAbundance<0f)
        {
            resourceAbundance = 0f;
        }
        //Console.WriteLine("Resource abundance: " + resourceAbundance);
        Console.WriteLine($"Environment Update: Temp={temperature}°C, Humidity={humidity}%, Weather={weather}, Daytime={isDayTime}, Resources={resourceAbundance}");

    }
    void SimulateEnvironment()
    {
        if (isDayTime)
        {
            temperature += (float)(new Random().NextDouble() * 4f - 2f);   // 日中は気温が上昇
        }
        else
        {
            temperature -= (float)(new Random().NextDouble() * 4f - 2f);   // 夜間は気温が低下
        }

       // Console.WriteLine("Current temperature: " + temperature);

        humidity += (float)(new Random().NextDouble() * 5f - 2.5f);         // 湿度が毎回少し変化

        // 天候変化
        int weatherRoll = new Random().Next(0, 100);
        if (weatherRoll < 10) weather = WeatherType.Rainy;
        else if (weatherRoll < 20) weather = WeatherType.Snowy;
        else if (weatherRoll < 25) weather = WeatherType.Storm;
        else weather = WeatherType.Sunny;
    }

    // 資源を提供する関数
    public float GetResourceAvailability()
    {
        return resourceAbundance;
    }
}