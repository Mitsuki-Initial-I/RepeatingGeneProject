using System;

/// <summary>
/// �������m�̑��ݍ�p�Ɨh��s�����Ǘ�
/// </summary>
public class SocialBehavior
{
    public bool isLeader = false;
    public float socialRank = 1f;       // �Љ�I�ȏ���(���l�������قǐg��������)

    //private void Start()
    //{
    //    if (isLeader)
    //    {
    //        Debug.Log("This creature is the leader of the group");
    //    }
    //}
    public void InteractWith(Creature other)
    {
        // �Љ�I���ݍ�p�̃V�~�����[�V����
        if (isLeader)
        {
            Console.WriteLine("This creature is leading.");
        }
        else if(socialRank > other.socialRank)
        {
            Console.WriteLine("This crature is dominant.");
        }
        else
        {
            Console.WriteLine("This creature is submissive.");
        }
    }
}