using System;

/// <summary>
/// 喜怒哀楽を管理する感情システム
/// </summary>
public class Emotion 
{
    public float joy = 50f;
    public float anger = 0f;
    public float sorrow = 0f;
    public float fear = 0f;

    public void ReactToEvent(string eventType)
    {
        switch (eventType)
        {
            case "FoodFound":
                
                break;
            default:
                break;
        }
    }

    void IncreaseJoy(float amount)
    {
        joy += amount;
        if (joy >100f)
        {
            joy = 100f;
        }
        Console.WriteLine("Joy increased. Current joy: " + joy);
    }

    void IncreaseAnger(float amount)
    {
        anger += amount;
        if (anger > 100f)
        {
            anger = 100f;
        }
        Console.WriteLine("Anger increased. Current anger: " + anger);
    }

    void IncreaseSorrow(float amount)
    {
        sorrow += amount;
        if (sorrow > 100f)
        {
            sorrow = 100f;
        }
        Console.WriteLine("Sorrow increased. Current sorrow: " + sorrow);
    }

    void IncreaseFear(float amount)
    {
        fear += amount;
        if (fear > 100f)
        {
            fear = 100f;
        }
        Console.WriteLine("Fear increased. Current fear: " + fear);
    }
}