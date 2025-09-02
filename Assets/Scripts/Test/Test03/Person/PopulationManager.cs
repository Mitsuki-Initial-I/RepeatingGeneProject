using System.Collections.Generic;
using UnityEngine;
namespace RepeatingGeneProject.Test03
{
    /// <summary>
    /// 人口管理クラス
    /// </summary>
    public class PopulationManager
    {
        // 現在の人口
        private List<Person> nowPersons = new List<Person>();

        // 人の生成
        public Person CreatePerson(int myId, string firstName, string lastName, Gender myGender, Color myColor, int attack, int defense, int speed)
        {
            Person newPerson = new Person(myId, firstName, lastName, myGender, myColor, attack, defense, speed);
            nowPersons.Add(newPerson);
            Debug.Log($"Number{newPerson.MyID}の{newPerson.GetFullName()}が生まれました");
            return newPerson;
        }
        public Person CreatePerson(Person gewPerson)
        {
            Person newPerson = new Person(gewPerson);
            nowPersons.Add(newPerson);
            Debug.Log($"Number{newPerson.MyID}の{newPerson.GetFullName()}が生まれました");
            return newPerson;
        }

        // 子供の生成
        public Person CreateGeneration(Person mother, Person father, int currentGeneration)
        {
            Person child = new Person(default)
            {
                MyMother = mother,
                MyFather = father,
                MyGender = Person.RandomGender(),
            };
            child.LastName = child.InheritLastName();
            child.MyColor = child.InheritColor();
            child.Attack = child.InheritStat(mother.Attack, father.Attack);
            child.Defense = child.InheritStat(mother.Defense, father.Defense);
            child.Speed = child.InheritStat(mother.Speed, father.Speed);
            child.MyID =
                currentGeneration * 10000 +
                (int)child.MyGender * 1000 +
                Random.Range(0, 1000);
            CreatePerson(child);
            return child;
        }

        void Test()
        {
            int maleNum = 0;
            int femaleNum = 0;


        }

        // 人口の生成
        public void GeneratePopulation()
        {
            int remainingGenerations = 3;
            for (int i = 0; i < remainingGenerations; i++)
            {

            }
        }
    }
}