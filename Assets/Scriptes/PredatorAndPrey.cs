using UnityEngine;

/// <summary>
/// 捕食と被食の関係シミュレーション
/// </summary>
public class PredatorAndPrey : MonoBehaviour
{
    public bool isPredator = false;
    public bool isPrey = false;

    private void Update()
    {
        if (isPredator)
        {
            Hunt();
        }
        if (isPrey)
        {
            AvoidPredator();
        }
    }
    void Hunt()
    {
        Debug.Log("Predator is hunting.");
    }

    void AvoidPredator()
    {
        Debug.Log("Prey is avoiding predator.");
    }
}