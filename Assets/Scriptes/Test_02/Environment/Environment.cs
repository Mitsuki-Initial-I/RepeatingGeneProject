using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

/// <summary>
/// ���N���X
/// </summary>
public class Environment
{
    public int SimulationDays { get; private set; }
    public int MaxSimulationDays { get; private set; }
    public float ResourceAmount { get; set; }
    public float Temperature { get; set; }
    public ConcurrentBag<Creature> Creatures { get; private set; }
    private Random random = new Random();

    // �G���[
    public string ErrorStr { get; set; }

    public bool IsError { get; set; } = false;
    public Environment(float initialResources, int maxSimulationDays = 100)
    {
        SimulationDays  = 0;
        MaxSimulationDays = maxSimulationDays;
        ResourceAmount = initialResources;
        Temperature = 20f;
        Creatures = new ConcurrentBag<Creature>();
    }

    public void AddCreature(Creature creature)
    {
        Creatures.Add(creature);
    }

    public void RemoveCreature(Creature creature)
    {
        if (Creatures.Equals(creature))
        {
            Creatures.TryTake(out creature);
        }
    }

    public void SimulateDay()
    {
        if (SimulationDays  >= MaxSimulationDays)
        {
            EndSimulation();
            return;
        }

        // ���̕ω�
        ResourceAmount += random.Next(-10, 20);
        Temperature += (float)(random.NextDouble() * 2 - 1);

        var creaturesToRemove = new List<Creature>();

        try
        {
            // ���ɍ��킹���s��
            foreach (var creature in Creatures)
            {
                creature.AgeUp();

                if (creature.IsPredator)
                {
                    // �ߐH�҂̍s��
                    if (creature.Prey.Count > 0)
                    {
                        var prey = creature.Prey[random.Next(creature.Prey.Count)];
                        creature.Eat(prey);
                    }
                }
                creature.Reproduce(this);
                creature.AdaptToEnvironment(Temperature);

                if (creature.Age >= creature.Lifespan)
                {
                    creaturesToRemove.Add(creature);
                }

                if (!creature.IsAlive())
                {
                    Console.WriteLine($"{creature.Name} has died.");
                }

                // �ɐB�`�F�b�N
                creature.Reproduce(this);
                // �i��
                creature.AdaptToEnvironment(Temperature);
            }
        }
        catch (Exception ex)
        {
            ErrorStr = ex.Message;
            IsError = true;
        }
        foreach (var creature in creaturesToRemove)
        {
            RemoveCreature(creature);
        }

        SimulationDays++;
        Console.WriteLine($"Resource replenished, current resource amount: {ResourceAmount}");
    }
    private void EndSimulation()
    {
        // �V�~�����[�V�����I��
        Console.WriteLine("Simulation ended after " + SimulationDays  + "days");
    }
}