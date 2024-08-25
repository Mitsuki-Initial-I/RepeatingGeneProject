using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace RepeatingGeneProject.Test01
{
    public class GeneTestSystem : MonoBehaviour
    {
        // ê¢ë„êî
        public int numberOfGenerations = 3;

        public int firstDataNum = 30;
        List<RPGStats> statusDataList = new List<RPGStats>();
        List<RPGStats> statusDataList_child = new List<RPGStats>();

        public void WriteToFile(string folderName, string fileName,string content)
        {
            string folderPath = Path.Combine(Application.dataPath, folderName);
            
            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, fileName);

            try
            {
                using (StreamWriter writer =new StreamWriter(filePath, false))
                {
                    writer.WriteLine(content);
                    Debug.Log("Path: " + filePath);
                }
            }
            catch(IOException e)
            {
                Debug.LogError("ÉGÉâÅ[: " + e.Message);
            }

        }


        private void Start()
        {
            string txtText = "";
            // èÓïÒê›íË
            for (int i = 0; i < firstDataNum; i++)
            {
                Color newColor = Color.white;
                int rnd = Random.Range(0, 5);
                switch (rnd)
                {
                    case 0:
                        newColor = Color.red;
                        break;
                    case 1:
                        newColor = Color.blue;
                        break;
                    case 2:
                        newColor = Color.green;
                        break;
                    case 3:
                        newColor = Color.black;
                        break;
                    case 4:
                        newColor = Color.white;
                        break;
                    default:
                        newColor = Color.white;
                        break;
                }
                RPGStats newStats = new RPGStats
                {
                    myColor = newColor,
                    myNumber = i,
                    Attack = Mathf.RoundToInt(newColor.r * 100),
                    Defense = Mathf.RoundToInt(newColor.g * 100),
                    Speed = Mathf.RoundToInt(newColor.b * 100)
                };
                statusDataList.Add(newStats);
                txtText += newStats.DisplayStats();
            }
            WriteToFile("é¿å±1", "0ê¢ë„.txt", txtText);
            int itemNum = statusDataList.Count;
            txtText = "";
            for (int i = 0; i < numberOfGenerations; i++)
            {
                for (int j = 0; j < itemNum / 2; j++)
                {
                    ChildData childData = new ChildData();
                    if (statusDataList.Count <= 1)
                    {
                        break;
                    }
                    else
                    {
                        childData.parent_0 = statusDataList[0];
                        childData.parent_1 = statusDataList[1];
                        Color newColor = (childData.parent_0.myColor + childData.parent_1.myColor) / 2.0f;
                        childData.childStats = new RPGStats
                        {
                            myColor = newColor,
                            myNumber = i * 100 + j,
                            Attack = Mathf.RoundToInt(newColor.r * 100),
                            Defense = Mathf.RoundToInt(newColor.g * 100),
                            Speed = Mathf.RoundToInt(newColor.b * 100)
                        };
                        statusDataList_child.Add(childData.childStats);
                        txtText += childData.DisplayStats();
                        statusDataList.Remove(statusDataList[1]);
                        statusDataList.Remove(statusDataList[0]);
                    }
                }
                statusDataList.AddRange(statusDataList_child);
                statusDataList_child = new List<RPGStats>();
                WriteToFile("é¿å±1", $"{i+1}ê¢ë„.txt", txtText);
                txtText = "";
            }
        }
    }
}