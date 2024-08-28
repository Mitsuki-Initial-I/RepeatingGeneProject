using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RepeatingGeneProject.Test02
{
    /// <summary>
    /// �l���v�f
    /// </summary>
    public class FamilyTreeNode : MonoBehaviour
    {
        public Person person;               // �Ή�����Person�I�u�W�F�N�g
        public Text nameText;               // ���O��\������e�L�X�gUI
        public Image colorImage;            // �F��\������C���[�WUI
        public LineRenderer lineRenderer;   // �e�q�֌W���������C��

        public void Initealize(Person person)
        {
            this.person = person;
            nameText.text = person.GetFullName();
            colorImage.color = person.MyColor;
        }
        public void DrawLineTo(FamilyTreeNode parentNode)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, parentNode.transform.position);
            lineRenderer.SetPosition(1, this.transform.position);
        }
    }
}
