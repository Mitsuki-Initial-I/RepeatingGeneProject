
using UnityEngine;

namespace RepeatingGeneProject.Test03
{
    /// <summary>
    /// 人物データ
    /// </summary>
    public class Person
    {
        #region 情報
        public int MyID { get; set; }

        // 名前
        public string FirstName { get; set; }
        // 苗字
        public string LastName { get; set; }
        // 性別
        public Gender MyGender { get; set; }
        // イメージカラー
        public Color MyColor { get; set; }
        // 攻撃
        public int Attack { get; set; }
        // 防御
        public int Defense { get; set; }
        // 俊敏
        public int Speed { get; set; }

        // 両親
        public Person MyMother { get; set; }
        public Person MyFather { get; set; }

        #endregion

        // コンストラクタ
        public Person(int myId, string firstName, string lastName, Gender myGender, Color myColor, int attack, int defense, int speed)
        {
            MyID = myId;
            FirstName = firstName;
            LastName = lastName;
            MyGender = myGender;
            MyColor = myColor;
            Attack = attack;
            Defense = defense;
            Speed = speed;
        }
        public Person(Person newPerson)
        {
            MyID = newPerson.MyID;
            FirstName = newPerson.FirstName;
            LastName = newPerson.LastName;
            MyGender = newPerson.MyGender;
            MyColor = newPerson.MyColor;
            Attack = newPerson.Attack;
            Defense = newPerson.Defense;
            Speed = newPerson.Speed;
        }

        // フルネーム
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        // ランダム性別
        public static Gender RandomGender()
        {
            return Random.value == 0.5f ? Gender.asexual :
                Random.value > 0.5f ? Gender.Male : Gender.Female;
        }

        // 継承 苗字
        public string InheritLastName()
        {
            if (MyFather != null)
            {
                return MyFather.LastName;
            }
            else if (MyMother != null)
            {
                return MyMother.LastName;
            }
            else
            {
                return LastName;
            }
        }

        // 継承　イメージカラー
        public Color InheritColor()
        {
            if (MyMother == null && MyFather == null)
            {
                return MyColor;
            }

            Color inheritedColor =
                Color.Lerp(MyMother.MyColor, MyFather.MyColor, 0.5f);

            return inheritedColor;
        }

        // 継承　能力
        public int InheritStat(int motherStat, int fatherStat)
        {
            int average = (motherStat + fatherStat) / 2;
            int variation = Random.Range(-100, 100);
            return Mathf.Clamp(average + variation, 0, 100);
        }

        // 情報出力用(Debug用)
        public string GetPersonInfo()
        {
            return $"ID:{MyID}\n名前:{GetFullName()}\n性別:{MyGender}\nイメージカラー:{MyColor}\n" +
                "ステータス:{" + Attack + "," + Defense + "," + Speed + "}";
        }
    }
}