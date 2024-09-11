using UnityEngine;

/// <summary>
/// ���N��Ԃƕa�C�Ȃǂ��Ǘ�
/// </summary>
public class HealthSystem : MonoBehaviour
{
    public float health = 100f;     // ���N���
    public bool isSick = false;     // �a�C���ǂ���
    public bool isInjured = false;  // ���䂵�Ă��邩�ǂ���

    private float sicknessDuration = 0f;

    private void Update()
    {
        // �a�C�̐i�s����
        if (isSick)
        {
            sicknessDuration += Time.deltaTime;
            health -= 0.1f * Time.deltaTime;        // �a�C�ŏ��������N������
            if (sicknessDuration > 10f)
            {
                
            }
        }

        // ����̉e������
        if (isInjured)
        {
            health -= 0.05f * Time.deltaTime;       // ����Ō��N������
        }
        Debug.Log("Current health: " + health);
    }

    // �a�C�ɂȂ�
    public void GetSick()
    {
        isSick = true;
        Debug.Log("Creature has fallen ill.");
    }

    // �a�C����񕜂���
    void RecoverFromSickness()
    {
        isSick = false;
        sicknessDuration = 0f;
        Debug.Log("Creature ha recovered from illness.");
    }

    // ����𕉂�
    public void GetInjured()
    {
        isInjured = true;
        Debug.Log("Creature is injured.");
    }

    // ���������
    public void HealInjury()
    {
        isInjured = false;
        Debug.Log("Creature's injury has healed.");
    }
}