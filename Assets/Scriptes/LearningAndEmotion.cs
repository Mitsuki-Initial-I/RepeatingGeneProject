using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ɂ���čs���ω�
/// </summary>
public class LearningAndEmotion : MonoBehaviour
{
    public float happiness = 50f;       // �K���x
    public float fear = 0f;             // ���|�̓x����

    private void Update()
    {
        // �w�K�Ɋ�Â��čs����ς���
        if(happiness>80f)
        {
            Debug.Log("Creature is happy and behaves positively.");
        }
        else if(fear>50f)
        {
            Debug.Log("Creature is scared and avoids danger.");
        }
    }
    
    // �w�K�ɂ��ꏊ�̋L��
    public void RememberPlace(Vector3 place)
    {
        Debug.Log("Creature remembers this place: " + place);
    }

    // ����̕ω�
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