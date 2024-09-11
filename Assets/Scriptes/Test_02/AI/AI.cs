using System;
using System.Collections.Generic;

public class AI
{
    public Creature Creature { get; set; }
    public Morality Morality { get; set; }
    public List<Emotion> Emotions { get; set; }

    public AI(Creature creature,Morality morality)
    {
        Creature = creature;
        Morality = morality;
        Emotions = new List<Emotion>();
    }

    public void Think()
    {
        foreach (var emotion in Emotions)
        {
            Morality.AdjustBasedOnEmotion(emotion);
        }

        // ”»’f‚ÉŠî‚Ã‚¢‚Äs“®‚ðŒˆ’è
        if (Morality.Aggression>Morality.Compassion)
        {
            Console.WriteLine($"{Creature.Name} choses to fight.");
        }
        else
        {
            Console.WriteLine($"{Creature.Name} choses to help others.");
        }
    }

    public void AddEmotion(Emotion emotion)
    {
        Emotions.Add(emotion);
        Console.WriteLine($"{Creature.Name} feels {emotion.Type} with intensity {emotion.Intensity}.");
    }
}