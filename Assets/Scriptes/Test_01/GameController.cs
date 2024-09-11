using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �V�~�����[�g�Ǘ�
/// </summary>
public class GameController : MonoBehaviour
{
    public Creature[] creatures;
    public Environment environment;

    private void Start()
    {
        environment = new Environment();
        creatures = new Creature[5];

        //for (int i = 0; i < creatures.Length; i++)
        //{
        //    creatures[i] = new Creature();
        //}
        creatures[0] = new Creature(DietType.Herbivore);
        creatures[1] = new Creature(DietType.Herbivore);
        creatures[2] = new Creature(DietType.Carnivore);
        creatures[3] = new Creature(DietType.Omnivore);
        creatures[4] = new Creature(DietType.Carnivore);
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;

        // ���X�V
        environment.Update(deltaTime);

        // �����̏�Ԃ��X�V
        foreach (Creature creature in creatures)
        {
            creature.Update(deltaTime, environment, creatures);

            if (Random.Range(0, 10) > 5)
            {
                creature.PerformAction("HelpFriend");
            }
            else
            {
                creature.PerformAction("Overeat");
            }
        }
    }
}