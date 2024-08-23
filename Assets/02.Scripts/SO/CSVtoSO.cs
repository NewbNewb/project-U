using System.IO;
using UnityEditor;
using UnityEngine;

public class CSVtoSO
{
    private static string monsterCSVPach = "/99.Resources/CSVFile/SampleMonster.csv";

    [MenuItem("Update/MonsterCSVtoSO")]
    public static void MonsterCSVtoSO()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + monsterCSVPach);
        bool firstSkip = true; // 첫 문단은 넘기기 위한 bool

        MonstersStatusSO monstersStatusSO = ScriptableObject.CreateInstance<MonstersStatusSO>();


        foreach (string s in allLines)
        {
            if (firstSkip)
            {
                firstSkip = false; // 첫 라인 스킵
                continue;
            }

            string[] splitData = s.Split(",");

            if (splitData.Length != 4 ) // 4칸이 아닐 경우 예외처리
            {
                Debug.LogError("값이 4칸이 아니라서 실행불가");
                return;
            }

            MonstersStatusSO.Monsters monsters = new MonstersStatusSO.Monsters();
            // 초기화인데 스텟이 늘어나거나 줄어 들 수록 수정해야 함
            monsters.name = splitData[0].Trim();
            monsters.grade = splitData[1].Trim();
            monsters.speed = float.Parse(splitData[2].Trim());
            monsters.health = int.Parse(splitData[3].Trim());

            monstersStatusSO.monsters.Add(monsters);
        }
        AssetDatabase.CreateAsset(monstersStatusSO, $"Assets/03.SOData/SampleMonster.asset");
        AssetDatabase.SaveAssets();
    }
}
