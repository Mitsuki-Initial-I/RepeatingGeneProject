using System;
using System.Collections.Generic;

/// <summary>
/// �����̊�{�s��
/// </summary>
public class Creature
{
    public float speed = 5f;            // ���x
    public float energy = 100f;         // �G�l���M�[
    public float hydration = 100f;      // ����
    public float lifespan = 100f;       // ����
    public float hunger = 100f;         // �H�~
    public float sleepiness = 0f;       // ���C
    public float matingDesire = 50f;    // ���~
    public float socialRank = 1f;       // �Љ�I����

    private float age = 0f;             // �N��
    private float actionTimer = 0f;     // �s������

    public State currentState;          // ���̍s�����
    public DietType dietType;           // ������
    public Emotion emotion;             // ����
    public Morality morality;           // ����

    public AIThoughtProcess thoughtProcess;     // �v�l

    public Creature(DietType diet)
    {
        dietType = diet;
        currentState = State.Moving;
        emotion = new Emotion();
        morality = new Morality();
        thoughtProcess = new AIThoughtProcess();
    }

    public void Update(float deltaTime, Environment environment,Creature[] outherCreatures)
    {
        // ����⓹���������X�V
        if (environment.GetResourceAvailability() < 0.2f)
        {
            emotion.ReactToEvent("FoodFound");
            morality.CommitAction("StealFood");
        }

        // �N��̍X�V�Ǝ����̊m�F
        age += deltaTime;
        if (age >= lifespan)
        {
            Die();
            return;
        }

        // �s���X�e�[�g�̏���
        HandleState(environment);

        // ���ւ̓K���`�F�b�N
        AdaptToEnvironment(environment);

        // AI�̎v�l�v���Z�X���Ăяo���āA�V�����s���𔭑z
        thoughtProcess.Think(environment, this);

        // �ߐH�s��
        foreach (var other in outherCreatures)
        {
            if (this !=other&&FoodChain.CanEat(this,other))
            {
                AI_PerformAction("Hunt", other);
                break;
            }
        }

        // ���z���ꂽ�s�����烉���_����1��I��Ŏ��s
        List<string> availableActions = thoughtProcess.GetAvailableActions();
        string chosenAction = availableActions[new Random().Next(availableActions.Count)];

        AI_PerformAction(chosenAction,null);
    }

    // ���ւ̓K��
    public void AdaptToEnvironment(Environment environment)
    {
        // �C���ւ̓K��
        if (environment.temperature < 0f || environment.temperature > 35f)
        {
            Console.WriteLine("Creature is uncomfortable with the temperature.");
            energy -= 0.5f; // �G�l���M�[���Ղ�������
        }

        // ���x�ւ̓K��
        if (environment.humidity < 20f || environment.humidity > 80f)
        {
            Console.WriteLine("Creature is uncomfortable with the humidity.");
            hydration -= 0.5f; // �������Ղ�������
        }

        // �V��ւ̓K��
        if (environment.weather==WeatherType.Storm)
        {
            Console.WriteLine("Creature is hiding from the storm.");
            energy -= 1f; // ���ł̓G�l���M�[���Ղ��������Ȃ�
        }

        // �n�`�ɂ��s���K��
        switch (environment.terrain)
        {
            case TerrainType.Forest:
                Console.WriteLine("Creature is adapting to the forest.");
                break;
            case TerrainType.Desert:
                Console.WriteLine("Creature is seeking water in the desert.");
                hydration -= 1f;    // �����ł͐������Ղ�������
                break;
            case TerrainType.Mountain:
                Console.WriteLine("Creature is struggling in the mountains.");
                energy -= 0.5f;     // �R�x�n�тł͈ړ�������
                break;
            default:
                break;
        }
    }

    // �s���̎��s
    public void AI_PerformAction(string action,Creature target)
    {
        Console.WriteLine("Performing action: " + action);

        // �����̍s����V�����s���ɉ���������
        switch (action)
        {
            case "Move":
                Console.WriteLine("Moving...");
                break;
            case "SeekFood":
                Console.WriteLine("Seeking food...");
                break;
            case "Hunt":
                Console.WriteLine("Hunting for prey...");
                if (target!=null)
                {
                    Console.WriteLine("Hunting and eating: " + target);
                    // �G�l���M�[��
                    energy += 50f;
                    target.energy = 0f; // �ߐH�Ώۂ̃G�l���M�[�͖�����
                }
                break;
            case "Scavenge":
                Console.WriteLine("Scavenging for food...");
                break;
            case "Sleep":
                Console.WriteLine("Sleeping...");
                energy += 20f;      // �����ŃG�l���M�[��
                break;
            case "DrinkWater":
                Console.WriteLine("Drinking water...");
                hydration += 20f;      // �����⋋
                break;
            case "Mate":
                Console.WriteLine("Mating...");
                break;
            case "HelpFriend":
                Console.WriteLine("Helping a friend...");
                break;
            default:
                Console.WriteLine("Unknown action.");
                break;
        }
    }

    public void PerformAction(string action)
    {
        switch (action)
        {
            case "HelpFriend":
                emotion.ReactToEvent("HelpFriend");
                morality.CommitAction("FriendLost");
                break;
            case "Overeat":
                emotion.ReactToEvent("Overeat");
                morality.CommitAction("FoodFound");
                break;
            default:
                break;
        }
    }

    // ��Ԃ��Ƃ̍s������
    void HandleState(Environment environment)
    {
        switch (currentState)
        {
            case State.Moving:
                Move();
                if (hunger <= 20) currentState = State.SeekingFood;
                else if (sleepiness >= 80) currentState = State.SeekingSleep;
                else if (matingDesire >= 80) currentState = State.Mating;
                break;
            case State.SeekingFood: SeekFood(environment);break;
            case State.Eating: Eat();break;
            case State.SeekingSleep:SeekSleep();break;
            case State.Sleeping:Sleep();break;
            case State.Mating: Mating();break;
        }
    }

    void Move() 
    {
        Console.WriteLine("Moving..."); 
    }
    void SeekFood(Environment environment) 
    { 
        Console.WriteLine("Seeking food...");
        if (environment.GetResourceAvailability()>0.5f)
        {
            currentState = State.Eating;
        }
    }
    void Eat() 
    { 
        Console.WriteLine("Eating...");
        hunger += 50f;
        if (hunger > 100f) hunger = 100f;
        currentState = State.Moving;
        //RestorHunger(50f); 
    }
    void SeekSleep() 
    {
        Console.WriteLine("Seeking sleep...");
        currentState = State.Sleeping;
    }
    void Sleep() 
    {
        Console.WriteLine("Sleeping...");
        sleepiness = 0f;
        energy = 100f;
        currentState = State.Moving;
        //RestoreSleepiness(100f);
    }
    void Mating() 
    {
        Console.WriteLine("Mating..."); 
        matingDesire = 0f;
        currentState = State.Moving;
    }
    // void RestorHunger(float amount) { hunger = Mathf.Min(hunger + amount, 100f); }
    // void RestoreSleepiness(float amount) { sleepiness = Mathf.Max(sleepiness - amount, 0f); }
    void Die() 
    {
        currentState = State.Dead;
        Console.WriteLine("Creature has died."); 
    }
}