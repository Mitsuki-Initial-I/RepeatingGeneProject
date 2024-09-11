using System;
using System.Collections.Generic;
using System.Security.Claims;

/// <summary>
/// 生物の基本的な行動クラス
/// </summary>
public class Creature
{
    public int Lifespan { get; private set; }               // 最大寿命
    public string Name { get; private set; }        // 名前
    public float Energy { get; set; }               // エネルギー
    public float Age { get; set; }      
    public float Hunger { get; set; }
    public bool IsPredator { get; private set; }
    public List<Creature> Prey { get; private set; }    // 捕食対象
    public GeneticInfo Genes { get; private set; }      // 遺伝子情報

    public Creature(string name,float energy,
        float hunger , GeneticInfo genes=null,
        bool isPredator = false)
    {
        Name = name;
        Energy = energy;
        Hunger = hunger;
        Age = 0f;
        Lifespan = new Random().Next(60,120);
        IsPredator = isPredator;
        Prey = new List<Creature>();
        Genes = genes ?? GenerateRandomGenes();  // 遺伝子情報が指定されない場合はランダムに生成
    }
    private GeneticInfo GenerateRandomGenes()
    {
        return new GeneticInfo
        {
            Strength = new Random().Next(1, 100),
            Speed = new Random().Next(1, 100),
            Intelligence = new Random().Next(1, 100)
        };
    }

    public void AddPrey(Creature prey)
    {
        Prey.Add(prey);
    }
    
    // 社会的行動
    public void Interact(Creature other)
    {
        if (IsPredator&&other.IsPredator)
        {
            // 捕食者同士の争い
            Energy -= 10;
        }
        else if (!IsPredator&&!other.IsPredator)
        {
            // 非捕食者同士の協力
            Energy += 5;
        }
    }
    
    // 狩猟

    // 食べる
    public void Eat(Creature prey)
    {
        if (Prey.Contains(prey))
        {
            Energy += prey.Energy * 0.5f;
            Hunger -= 10;
            if (Hunger < 0)
            {
                Hunger = 0;
            }
            Prey.Remove(prey);
            Console.WriteLine($"{Name} ate and gained {prey.Energy} energy.");
        }
    }

    // 寝る
    public void Sleep()
    {
        Energy += 10f;
        Console.WriteLine($"{Name} is sleeping and regaining energy");
    }

    // 老い
    public void AgeUp()
    {
        Age++;
        Energy -= 5f;
        Hunger += 5f;
        Energy -= Genes.Strength / 10;

        if (Age>=Lifespan)
        {
            Die();
        }

        Console.WriteLine($"{Name} aged. Current Age: {Age}, Energy: {Energy}, Hunger: {Hunger}");
    }

    // 繁殖
    public void Reproduce(Environment environment)
    {
        // 繁殖条件設定
        if (Age > 2 && Energy > 50)
        {
            // 新しい生物を生成
            Creature offspring = new Creature(Name, Energy / 2, Hunger / 2, MutateGenes(),IsPredator);
            environment.AddCreature(offspring);
            Energy -= 10;
        }
    }

    // 環境進化
    public void AdaptToEnvironment(float temperature)
    {
        // 環境に適応する為の進化
        if (temperature<15f)
        {
            // 低温適応
            Genes.Speed += 5;
        }
        else if (temperature>25f)
        {
            // 高温適応
            Genes.Strength += 5;
        }
        // 遺伝子の範囲を制限
        Genes.Speed = Clamp(Genes.Speed, 1, 100);
        Genes.Strength = Clamp(Genes.Speed, 1, 100);
    }

    // 適応度
    public float CalculateAdaptationScore(float temperature)
    {
        float score = 0;
        if (temperature<15f)
        {
            score = Genes.Speed / 100f;
        }
        else if (temperature>25f)
        {
            score = Genes.Strength / 100f;
        }
        return score;
    }

    // 生存状態
    public bool IsAlive()
    {
        return Age < Lifespan && Energy > 0;
    }

    private GeneticInfo MutateGenes()
    {
        var random = new Random();
        return new GeneticInfo
        {
            Strength = Clamp(Genes.Strength + random.Next(-10, 10), 1, 100),
            Speed = Clamp(Genes.Speed + random.Next(-10, 10), 1, 100),
            Intelligence = Clamp(Genes.Intelligence + random.Next(-10, 10), 1, 100)
        };
    }
    private Environment GetEnvironment()
    {
        return null;
    }
    private int Clamp(int value,int min,int max)
    {
        return Math.Max(min, Math.Min(max, value));
    }

    private void Die()
    {
        Environment environment = GetEnvironment();
        if (environment!=null)
        {
            environment.RemoveCreature(this);
        }
    }
}