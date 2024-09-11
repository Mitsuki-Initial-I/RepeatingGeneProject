using System;

/// <summary>
/// �����V�X�e��
/// </summary>
public class Morality 
{
    public float pride = 0f;        // ����
    public float greed = 0f;        // ���~
    public float wrath = 0f;        // ���{
    public float envy = 0f;         // ���i
    public float lust = 0f;         // �F�~
    public float gluttony = 0f;     // �\�H
    public float sloth = 0f;        // �ӑ�

    public float humility = 50f;    // �����A�����A���`
    public float kindness = 50f;    // �~���A���ʁA���P
    public float generosity = 50f;  // ���e�A���߁A�E��
    public float patience = 50f;    // �E�ρA�����A�e�؁A�l��
    public float chastity = 50f;    // �����A�����A�F��A��i
    public float temperance = 50f;  // �ߐ��A����
    public float diligence = 50f;   // �ΕׁA��]�A�E�C


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