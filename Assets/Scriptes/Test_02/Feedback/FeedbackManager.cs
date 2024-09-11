using System;
using System.Collections.Generic;
using System.Linq;

public class FeedbackManager 
{
    private List<Creature> creatures;
    private LogManger logManger;

    public FeedbackManager(List<Creature> creatures,LogManger logManger)
    {
        this.creatures = creatures;
        this.logManger = logManger;
    }
    public void AnalyzeAdaptation(float temperature)
    {
        var adaptationScores = creatures.Select(c => new
        {
            Name = c.Name,
            Score = c.CalculateAdaptationScore(temperature)
        });

        float averageScore = adaptationScores.Average(a => a.Score);

        logManger.Log("Adaptation Analysis:");
        logManger.Log("Temperature: "+temperature);
        foreach (var score in adaptationScores)
        {
            logManger.Log($"{score.Name}: Adaptation Score = {score.Score}");
        }
        logManger.Log("Average Adaptation Score: "+averageScore);
    }
}
