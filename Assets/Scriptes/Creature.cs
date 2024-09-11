using System;
using System.Collections.Generic;

/// <summary>
/// 生物の基本行動
/// </summary>
public class Creature
{
    public float speed = 5f;            // 速度
    public float energy = 100f;         // エネルギー
    public float hydration = 100f;      // 水分
    public float lifespan = 100f;       // 寿命
    public float hunger = 100f;         // 食欲
    public float sleepiness = 0f;       // 眠気
    public float matingDesire = 50f;    // 性欲
    public float socialRank = 1f;       // 社会的序列

    private float age = 0f;             // 年齢
    private float actionTimer = 0f;     // 行動時間

    public State currentState;          // 今の行動状態
    public DietType dietType;           // 生物性
    public Emotion emotion;             // 感情
    public Morality morality;           // 道徳

    public AIThoughtProcess thoughtProcess;     // 思考

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
        // 感情や道徳反応を更新
        if (environment.GetResourceAvailability() < 0.2f)
        {
            emotion.ReactToEvent("FoodFound");
            morality.CommitAction("StealFood");
        }

        // 年齢の更新と寿命の確認
        age += deltaTime;
        if (age >= lifespan)
        {
            Die();
            return;
        }

        // 行動ステートの処理
        HandleState(environment);

        // 環境への適応チェック
        AdaptToEnvironment(environment);

        // AIの思考プロセスを呼び出して、新しい行動を発想
        thoughtProcess.Think(environment, this);

        // 捕食行動
        foreach (var other in outherCreatures)
        {
            if (this !=other&&FoodChain.CanEat(this,other))
            {
                AI_PerformAction("Hunt", other);
                break;
            }
        }

        // 発想された行動からランダムで1つを選んで実行
        List<string> availableActions = thoughtProcess.GetAvailableActions();
        string chosenAction = availableActions[new Random().Next(availableActions.Count)];

        AI_PerformAction(chosenAction,null);
    }

    // 環境への適応
    public void AdaptToEnvironment(Environment environment)
    {
        // 気温への適応
        if (environment.temperature < 0f || environment.temperature > 35f)
        {
            Console.WriteLine("Creature is uncomfortable with the temperature.");
            energy -= 0.5f; // エネルギー消耗が増える
        }

        // 温度への適応
        if (environment.humidity < 20f || environment.humidity > 80f)
        {
            Console.WriteLine("Creature is uncomfortable with the humidity.");
            hydration -= 0.5f; // 水分消耗が増える
        }

        // 天候への適応
        if (environment.weather==WeatherType.Storm)
        {
            Console.WriteLine("Creature is hiding from the storm.");
            energy -= 1f; // 嵐ではエネルギー消耗が激しくなる
        }

        // 地形による行動適応
        switch (environment.terrain)
        {
            case TerrainType.Forest:
                Console.WriteLine("Creature is adapting to the forest.");
                break;
            case TerrainType.Desert:
                Console.WriteLine("Creature is seeking water in the desert.");
                hydration -= 1f;    // 砂漠では水分消耗が激しい
                break;
            case TerrainType.Mountain:
                Console.WriteLine("Creature is struggling in the mountains.");
                energy -= 0.5f;     // 山岳地帯では移動が困難
                break;
            default:
                break;
        }
    }

    // 行動の実行
    public void AI_PerformAction(string action,Creature target)
    {
        Console.WriteLine("Performing action: " + action);

        // 既存の行動や新しい行動に応じた処理
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
                    // エネルギー回復
                    energy += 50f;
                    target.energy = 0f; // 捕食対象のエネルギーは無くす
                }
                break;
            case "Scavenge":
                Console.WriteLine("Scavenging for food...");
                break;
            case "Sleep":
                Console.WriteLine("Sleeping...");
                energy += 20f;      // 睡眠でエネルギー回復
                break;
            case "DrinkWater":
                Console.WriteLine("Drinking water...");
                hydration += 20f;      // 水分補給
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

    // 状態ごとの行動処理
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