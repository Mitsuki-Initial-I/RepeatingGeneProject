using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RepeatingGeneProject.Test02
{
    /// <summary>
    /// 人物クラス
    /// </summary>
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender MyGender { get; set; }
        public Color MyColor { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }

        public Person Parent_Mother { get; set; }
        public Person Parent_Father { get; set; }

        // コンストラクタ
        public Person(string firstName, string lastName, Gender myGender, Color myColor, int health, int strength, int intelligence)
        {
            FirstName = firstName;
            LastName = lastName;
            MyGender = myGender;
            MyColor = myColor;
            Health = health;
            Strength = strength;
            Intelligence = intelligence;
        }

        // フルネームを取得
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        // 性別の遺伝はランダムな選択
        public static Gender InheritGender(Person parent_0, Person parent_1)
        {
            return UnityEngine.Random.value > 0.5f ? parent_0.MyGender : parent_1.MyGender;
        }

        // 苗字を遺伝させる再起メソッド
        public string InheritLastName()
        {
            if(Parent_Father!=null)
            {
                return Parent_Father.InheritLastName();
            }
            else if(Parent_Mother!=null)
            {
                return Parent_Mother.InheritLastName();
            }
            else
            {
                return LastName;
            }
        }

        // 色を遺伝させるメソッド
        public Color InheritColor()
        {
            if(Parent_Mother==null&&Parent_Father==null)
            {
                return MyColor;
            }

            Color inheritedColor = Color.Lerp(Parent_Father.MyColor, Parent_Mother.MyColor, 0.5f);

            if (Parent_Mother.Parent_Mother!=null&&Parent_Mother.Parent_Father!=null)
            {
                inheritedColor = Color.Lerp(inheritedColor, Color.Lerp(Parent_Mother.Parent_Mother.MyColor, Parent_Mother.Parent_Father.MyColor, 0.5f), 0.25f);
            }

            if (Parent_Father.Parent_Mother != null && Parent_Father.Parent_Father != null)
            {
                inheritedColor = Color.Lerp(inheritedColor, Color.Lerp(Parent_Father.Parent_Mother.MyColor, Parent_Father.Parent_Father.MyColor, 0.5f), 0.25f);
            }

            return inheritedColor;
        }

        // ステータスを遺伝させるメソッド
        public int InheritStat(int parent1Stat,int parent2Stat)
        {
            int average = (parent1Stat + parent2Stat) / 2;
            int variation = UnityEngine.Random.Range(-10, 10);
            return Mathf.Clamp(average + variation, 0, 100);
        }

        // 人物情報の文字列
        public string GetPersonInfo()
        {
            return $"Name: {GetFullName()}, Gender: {MyGender}, Color: {MyColor}, Health: {Health}, Strength: {Strength}, Intelligence: {Intelligence}";
        }
    }
}