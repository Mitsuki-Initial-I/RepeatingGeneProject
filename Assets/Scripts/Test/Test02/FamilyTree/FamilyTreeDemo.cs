using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RepeatingGeneProject.Test02
{
    public class FamilyTreeDemo : MonoBehaviour
    {
        public FamilyTree familyTree;
        public PopulationManager populationManager=new PopulationManager();

        private void Start()
        {
            populationManager.GeneratePopulation(4);
            Person lastGeneration = populationManager.GetLastGeneration();

            if (lastGeneration!=null)
            {
                familyTree.BuildTree(lastGeneration, Vector2.zero, 300, 150);
            }
            else
            {
                Debug.LogError("ç≈å„ÇÃê¢ë„ÇÕå©Ç¬Ç©ÇËÇ‹ÇπÇÒÇ≈ÇµÇΩ");
            }
        }
    }
}