using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RepeatingGeneProject.Test02
{
    /// <summary>
    /// 人物要素
    /// </summary>
    public class FamilyTreeNode : MonoBehaviour
    {
        public Person person;               // 対応するPersonオブジェクト
        public Text nameText;               // 名前を表示するテキストUI
        public Image colorImage;            // 色を表示するイメージUI
        public LineRenderer lineRenderer;   // 親子関係を示すライン

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
