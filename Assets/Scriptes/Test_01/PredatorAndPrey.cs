using UnityEngine;

/// <summary>
/// �ߐH�Ɣ�H�̊֌W�V�~�����[�V����
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