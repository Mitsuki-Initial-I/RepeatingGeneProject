using System;

/// <summary>
/// ���V�~�����[�V����
/// </summary>
public class Environment 
{
    public float temperature;               // �C��
    public float humidity;                  // ���x
    public float resourceAbundance;         // �����̖L�x��
    public bool isDayTime;                  // ����T�C�N��

    public TerrainType terrain;             // �n�`
    public WeatherType weather;             // �V��

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
        // ����T�C�N���̏���
        cycleTimer += deltaTime;
        if (cycleTimer >= dayNightCycleDuration)
        {
            isDayTime = !isDayTime;
            cycleTimer = 0f;
            //Console.WriteLine(isDayTime ? "It's now daytime." : "It's now nighttime.");
        }

        // �V���C���A���x�������_���ɕω�
        SimulateEnvironment();

        // �����̎��������ԂƋ��ɕω�����
        resourceAbundance -= deltaTime * 0.01f;
        if (resourceAbundance<0f)
        {
            resourceAbundance = 0f;
        }
        //Console.WriteLine("Resource abundance: " + resourceAbundance);
        Console.WriteLine($"Environment Update: Temp={temperature}��C, Humidity={humidity}%, Weather={weather}, Daytime={isDayTime}, Resources={resourceAbundance}");

    }
    void SimulateEnvironment()
    {
        if (isDayTime)
        {
            temperature += (float)(new Random().NextDouble() * 4f - 2f);   // �����͋C�����㏸
        }
        else
        {
            temperature -= (float)(new Random().NextDouble() * 4f - 2f);   // ��Ԃ͋C�����ቺ
        }

       // Console.WriteLine("Current temperature: " + temperature);

        humidity += (float)(new Random().NextDouble() * 5f - 2.5f);         // ���x�����񏭂��ω�

        // �V��ω�
        int weatherRoll = new Random().Next(0, 100);
        if (weatherRoll < 10) weather = WeatherType.Rainy;
        else if (weatherRoll < 20) weather = WeatherType.Snowy;
        else if (weatherRoll < 25) weather = WeatherType.Storm;
        else weather = WeatherType.Sunny;
    }

    // ������񋟂���֐�
    public float GetResourceAvailability()
    {
        return resourceAbundance;
    }
}