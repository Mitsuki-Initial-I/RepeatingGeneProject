using System;

/// <summary>
/// 道徳システム
/// </summary>
public class Morality 
{
    public float pride = 0f;        // 傲慢
    public float greed = 0f;        // 強欲
    public float wrath = 0f;        // 憤怒
    public float envy = 0f;         // 嫉妬
    public float lust = 0f;         // 色欲
    public float gluttony = 0f;     // 暴食
    public float sloth = 0f;        // 怠惰

    public float humility = 50f;    // 謙虚、謙譲、忠義
    public float kindness = 50f;    // 救恤、分別、慈善
    public float generosity = 50f;  // 寛容、慈悲、忍耐
    public float patience = 50f;    // 忍耐、慈愛、親切、人徳
    public float chastity = 50f;    // 純潔、純愛、友情、上品
    public float temperance = 50f;  // 節制、分別
    public float diligence = 50f;   // 勤勉、希望、勇気


    public void CommitAction(string actionType)
    {
        switch (actionType)
        {
            case "StealFood":
                IncreaseGreed(10f);
                break;
            case "HelpFriend":
                IncreaseKindness(10f);
                break;
            case "Overeat":
                IncreaseGluttony(10f);
                break;
            case "ShowPatience":
                IncreasePatience(10f);
                break;
            default:
                Console.WriteLine("No moral significance.");
                break;
        }
    }

    void IncreaseGreed(float amount)
    {
        greed += amount;
        if (greed >100f)
        {
            greed = 100f;
        }
        Console.WriteLine("Greed increased. Current greed: " + greed);
    }
    void IncreaseKindness(float amount)
    {
        kindness += amount;
        if (kindness > 100f)
        {
            kindness = 100f;
        }
        Console.WriteLine("Kindness increased. Current kindness: " + kindness);
    }
    void IncreaseGluttony(float amount)
    {
        gluttony += amount;
        if (gluttony > 100f)
        {
            gluttony = 100f;
        }
        Console.WriteLine("Gluttony increased. Current gluttony: " + gluttony);
    }
    void IncreasePatience(float amount)
    {
        patience += amount;
        if (patience > 100f)
        {
            patience = 100f;
        }
        Console.WriteLine("Patience increased. Current patience: " + patience);
    }
}