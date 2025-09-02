using System;

/// <summary>
/// 生物同士の相互作用と揺れ行動を管理
/// </summary>
public class SocialBehavior
{
    public bool isLeader = false;
    public float socialRank = 1f;       // 社会的な序列(数値が高いほど身分が高い)

    //private void Start()
    //{
    //    if (isLeader)
    //    {
    //        Debug.Log("This creature is the leader of the group");
    //    }
    //}
    public void InteractWith(Creature other)
    {
        // 社会的相互作用のシミュレーション
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