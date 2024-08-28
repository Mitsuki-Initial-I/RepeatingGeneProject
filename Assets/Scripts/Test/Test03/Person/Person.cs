
using UnityEngine;

namespace RepeatingGeneProject.Test03
{
    /// <summary>
    /// �l���f�[�^
    /// </summary>
    public class Person
    {
        #region ���
        public int MyID { get; set; }

        // ���O
        public string FirstName { get; set; }
        // �c��
        public string LastName { get; set; }
        // ����
        public Gender MyGender { get; set; }
        // �C���[�W�J���[
        public Color MyColor { get; set; }
        // �U��
        public int Attack { get; set; }
        // �h��
        public int Defense { get; set; }
        // �r�q
        public int Speed { get; set; }

        // ���e
        public Person MyMother { get; set; }
        public Person MyFather { get; set; }

        #endregion

        // �R���X�g���N�^
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

        // �t���l�[��
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        // �����_������
        public static Gender RandomGender()
        {
            return Random.value == 0.5f ? Gender.asexual :
                Random.value > 0.5f ? Gender.Male : Gender.Female;
        }

        // �p�� �c��
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

        // �p���@�C���[�W�J���[
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

        // �p���@�\��
        public int InheritStat(int motherStat, int fatherStat)
        {
            int average = (motherStat + fatherStat) / 2;
            int variation = Random.Range(-100, 100);
            return Mathf.Clamp(average + variation, 0, 100);
        }

        // ���o�͗p(Debug�p)
        public string GetPersonInfo()
        {
            return $"ID:{MyID}\n���O:{GetFullName()}\n����:{MyGender}\n�C���[�W�J���[:{MyColor}\n" +
                "�X�e�[�^�X:{" + Attack + "," + Defense + "," + Speed + "}";
        }
    }
}