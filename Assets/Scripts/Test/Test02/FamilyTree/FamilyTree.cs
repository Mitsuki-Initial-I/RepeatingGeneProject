using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RepeatingGeneProject.Test02
{
    public class FamilyTree : MonoBehaviour
    {
        public GameObject nodePrefab;
        public Transform rootTransform;
        private List<FamilyTreeNode> allNodes = new List<FamilyTreeNode>();

        private FamilyTreeNode CrateNode(Person person,Vector2 position)
        {
            GameObject nodeObj = Instantiate(nodePrefab, rootTransform);
            nodeObj.transform.localPosition = position;

            FamilyTreeNode node = nodeObj.GetComponent<FamilyTreeNode>();
            node.Initealize(person);

            return node;
        }

        public FamilyTreeNode BuildTree(Person rootPerson,Vector2 position,float xSpacing,float ySpacing)
        {
            if (rootPerson == null) return null;

            FamilyTreeNode node = CrateNode(rootPerson, position);
            allNodes.Add(node);

            if(rootPerson.Parent_Mother!=null)
            {
                FamilyTreeNode parentNode_Mother = BuildTree(rootPerson.Parent_Mother, position + new Vector2(-xSpacing, -ySpacing), xSpacing / 2, ySpacing);
                if (parentNode_Mother!=null)
                {
                    node.DrawLineTo(parentNode_Mother);
                }
            }
            if (rootPerson.Parent_Father != null)
            {
                FamilyTreeNode parentNode__Father = BuildTree(rootPerson.Parent_Mother, position + new Vector2(-xSpacing, -ySpacing), xSpacing / 2, ySpacing);
                if (parentNode__Father != null)
                {
                    node.DrawLineTo(parentNode__Father);
                }
            }
            return node;
        }
    }
}
