using System;
using System.Collections.Generic;
using System.Security.Claims;

/// <summary>
/// �����̊�{�I�ȍs���N���X
/// </summary>
public class Creature
{
    public int Lifespan { get; private set; }               // �ő����
    public string Name { get; private set; }        // ���O
    public float Energy { get; set; }               // �G�l���M�[
    public float Age { get; set; }      
    public float Hunger { get; set; }
    public bool IsPredator { get; private set; }
    public List<Creature> Prey { get; private set; }    // �ߐH�Ώ�
    public GeneticInfo Genes { get; private set; }      // ��`�q���

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
        Genes = genes ?? GenerateRandomGenes();  // ��`�q��񂪎w�肳��Ȃ��ꍇ�̓����_���ɐ���
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
    
    // �Љ�I�s��
    public void Interact(Creature other)
    {
        if (IsPredator&&other.IsPredator)
        {
            // �ߐH�ғ��m�̑���
            Energy -= 10;
        }
        else if (!IsPredator&&!other.IsPredator)
        {
            // ��ߐH�ғ��m�̋���
            Energy += 5;
        }
    }
    
    // ���

    // �H�ׂ�
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

    // �Q��
    public void Sleep()
    {
        Energy += 10f;
        Console.WriteLine($"{Name} is sleeping and regaining energy");
    }

    // �V��
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

    // �ɐB
    public void Reproduce(Environment environment)
    {
        // �ɐB�����ݒ�
        if (Age > 2 && Energy > 50)
        {
            // �V���������𐶐�
            Creature offspring = new Creature(Name, Energy / 2, Hunger / 2, MutateGenes(),IsPredator);
            environment.AddCreature(offspring);
            Energy -= 10;
        }
    }

    // ���i��
    public void AdaptToEnvironment(float temperature)
    {
        // ���ɓK������ׂ̐i��
        if (temperature<15f)
        {
            // �ቷ�K��
            Genes.Speed += 5;
        }
        else if (temperature>25f)
        {
            // �����K��
            Genes.Strength += 5;
        }
        // ��`�q�͈̔͂𐧌�
        Genes.Speed = Clamp(Genes.Speed, 1, 100);
        Genes.Strength = Clamp(Genes.Speed, 1, 100);
    }

    // �K���x
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

    // �������
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