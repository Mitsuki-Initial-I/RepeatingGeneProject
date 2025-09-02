using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RepeatingGeneProject.Test02
{
    /// <summary>
    /// 人口管理クラス
    /// </summary>
    public class PopulationManager 
    {
        private List<Person> allPersons = new List<Person>();

        // 全ての人物の情報を表示する
        public void DisplayAllPersons()
        {
            foreach (var person in allPersons)
            {
                Debug.Log(person.GetPersonInfo());
            }
        }
        public Person CreatePerson(string firstName,string lastName,Gender myGender,Color myColor,int health,int strength,int intelligence)
        {
            Person person = new Person(firstName, lastName, myGender, myColor, health, strength, intelligence);
            allPersons.Add(person);
            return person;
        }

        public Person CreateGeneration(Person parent_Mother,Person parent_Father, int remainingGenerations)
        {
            if (remainingGenerations <= 0) return null;

            // 性別を遺伝
            Gender childGender = Person.InheritGender(parent_Mother, parent_Father);

            // 子供を生成
            Person child = new Person($"Child{remainingGenerations}", parent_Father.InheritLastName(),childGender, Color.white, 0, 0, 0)
            {
                Parent_Mother = parent_Mother,
                Parent_Father = parent_Father,
                MyColor = parent_Mother.InheritColor(),
                Health = parent_Mother.InheritStat(parent_Mother.Health, parent_Father.Health),
                Strength = parent_Mother.InheritStat(parent_Mother.Strength, parent_Father.Strength),
                Intelligence = parent_Mother.InheritStat(parent_Mother.Intelligence, parent_Father.Intelligence)
            };

            allPersons.Add(child);

            CreateGeneration(child, parent_Father, remainingGenerations - 1);
            CreateGeneration(parent_Mother, child, remainingGenerations - 1);
            return child;
        }
        public void GeneratePopulation(int generations)
        {
            // 最初の2人の親を作成
            Person parent_Mother = CreatePerson("John", "Smith", Gender.Male, Color.red, 100, 50, 75);
            Person parent_Father = CreatePerson("Jane", "Doe", Gender.Female, Color.blue, 90, 60, 85);

            CreateGeneration(parent_Mother, parent_Father, generations);

            // 生成された人物の情報を出力
            DisplayAllPersons();
        }
        public Person GetLastGeneration()
        {
            if (allPersons.Count == 0) return null;
            return allPersons[allPersons.Count - 1];
        }
        public List<Person> GetLastgenerationPeople()
        {
            List<Person> lastGeneration = new List<Person>();
            foreach (var person in allPersons)
            {
                if (person.Parent_Mother!=null&&person.Parent_Father!=null)
                {
                    lastGeneration.Add(person);
                }
            }
            return lastGeneration;
        }
    }
}