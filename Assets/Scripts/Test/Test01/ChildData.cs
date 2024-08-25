using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RepeatingGeneProject.Test01
{
    public class ChildData
    {
        public RPGStats childStats;

        public RPGStats parent_0;
        public RPGStats parent_1;

        public string DisplayStats()
        {
            Debug.Log($"Nober: {childStats.myNumber}\n ParentNumber: {parent_0.myNumber},{parent_1.myNumber}\n Attack: {childStats.Attack}\n Defense: {childStats.Defense}\n Speed: {childStats.Speed}\n Color: {childStats.myColor.r},{childStats.myColor.g},{childStats.myColor.b}");
           return $"Nober: {childStats.myNumber}\n ParentNumber: {parent_0.myNumber},{parent_1.myNumber}\n Attack: {childStats.Attack}\n Defense: {childStats.Defense}\n Speed: {childStats.Speed}\n Color: {childStats.myColor.r},{childStats.myColor.g},{childStats.myColor.b}";
        }
    }
}
