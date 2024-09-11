using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 感情によって行動変化
/// </summary>
public class LearningAndEmotion : MonoBehaviour
{
    public float happiness = 50f;       // 幸福度
    public float fear = 0f;             // 恐怖の度合い

    private void Update()
    {
        // 学習に基づいて行動を変える
        if(happiness>80f)
        {
            Debug.Log("Creature is happy and behaves positively.");
        }
        else if(fear>50f)
        {
            Debug.Log("Creature is scared and avoids danger.");
        }
    }
    
    // 学習による場所の記憶
    public void RememberPlace(Vector3 place)
    {
        Debug.Log("Creature remembers this place: " + place);
    }

    // 感情の変化
    public void ChangeEmotion(string emotion,float value)
    {
        switch (emotion)
        {
            case "happiness":
                happiness += value;
                break;
            case "fear":
                fear += value;
                break;
            default:
                break;
        }
    }
}