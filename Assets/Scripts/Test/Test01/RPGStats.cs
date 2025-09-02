using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RepeatingGeneProject.Test01
{
    [System.Serializable]
    public struct RPGStats
    {
        public Color myColor;
        public int myNumber;
        public int Attack;
        public int Defense;
        public int Speed;

        public string DisplayStats()
        {
            Debug.Log($"Nober: {myNumber}\n Attack: {Attack}\n Defense: {Defense}\n Speed: {Speed}\n Color: {myColor.r},{myColor.g},{myColor.b}");
            return $"Nober: {myNumber}\n Attack: {Attack}\n Defense: {Defense}\n Speed: {Speed}\n Color: {myColor.r},{myColor.g},{myColor.b}";
        }
    }
}