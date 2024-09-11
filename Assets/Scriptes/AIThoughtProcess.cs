using System;
using System.Collections.Generic;

/// <summary>
/// �v�l�̂��߂�AI�V�X�e��
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

    // ���������݂̊��𕪐͂��A�V�����s���𔭑z����
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

    // �V�����s���𔭑z
    private void GenerateNewAction(string actionName)
    {
        Console.WriteLine("New action generated: " + actionName);
        newlyGeneratedActions.Add(actionName);
    }
    // ���s�\�����ׂĂ̍s����Ԃ�
    public List<string> GetAvailableActions()
    {
        List<string> availableActions = new List<string>(knownActions);
        availableActions.AddRange(newlyGeneratedActions);
        return availableActions;
    }
}