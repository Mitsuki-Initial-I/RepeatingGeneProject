using System;
using System.Collections.Generic;

/// <summary>
/// 思考のためのAIシステム
/// </summary>
public class AIThoughtProcess 
{
    private List<string> knownActions;
    private List<string> newlyGeneratedActions;

    public AIThoughtProcess()
    {
        knownActions = new List<string> { "Move", "SeekFood", "Sleep", "Mate", "HelpFriend" };
        newlyGeneratedActions = new List<string>();
    }

    // 生物が現在の環境を分析し、新しい行動を発想する
    public void Think(Environment environment,Creature creature)
    {
        Console.WriteLine("Thinking...");

        if (environment.resourceAbundance<0.2f&&!knownActions.Contains("Hunt"))
        {
            GenerateNewAction("Hunt");
        }
        if (creature.hunger<30f&&!knownActions.Contains("Scavenge"))
        {
            GenerateNewAction("Scavenge");
        }
    }

    // 新しい行動を発想
    private void GenerateNewAction(string actionName)
    {
        Console.WriteLine("New action generated: " + actionName);
        newlyGeneratedActions.Add(actionName);
    }
    // 実行可能名すべての行動を返す
    public List<string> GetAvailableActions()
    {
        List<string> availableActions = new List<string>(knownActions);
        availableActions.AddRange(newlyGeneratedActions);
        return availableActions;
    }
}