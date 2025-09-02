using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RepeatingGeneProject.Test02
{
    public class MainProcess : MonoBehaviour
    {
        public int generationNum;


        PopulationManager manager = new PopulationManager();

        private void Start()
        {
            manager.GeneratePopulation(generationNum);
            manager.DisplayAllPersons();
        }
    }
}