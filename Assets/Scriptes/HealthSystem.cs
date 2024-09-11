using UnityEngine;

/// <summary>
/// 健康状態と病気などを管理
/// </summary>
public class HealthSystem : MonoBehaviour
{
    public float health = 100f;     // 健康状態
    public bool isSick = false;     // 病気かどうか
    public bool isInjured = false;  // 怪我しているかどうか

    private float sicknessDuration = 0f;

    private void Update()
    {
        // 病気の進行処理
        if (isSick)
        {
            sicknessDuration += Time.deltaTime;
            health -= 0.1f * Time.deltaTime;        // 病気で少しずつ健康が悪化
            if (sicknessDuration > 10f)
            {
                
            }
        }

        // 怪我の影響処理
        if (isInjured)
        {
            health -= 0.05f * Time.deltaTime;       // 怪我で健康が減少
        }
        Debug.Log("Current health: " + health);
    }

    // 病気になる
    public void GetSick()
    {
        isSick = true;
        Debug.Log("Creature has fallen ill.");
    }

    // 病気から回復する
    void RecoverFromSickness()
    {
        isSick = false;
        sicknessDuration = 0f;
        Debug.Log("Creature ha recovered from illness.");
    }

    // 怪我を負う
    public void GetInjured()
    {
        isInjured = true;
        Debug.Log("Creature is injured.");
    }

    // 怪我を治す
    public void HealInjury()
    {
        isInjured = false;
        Debug.Log("Creature's injury has healed.");
    }
}