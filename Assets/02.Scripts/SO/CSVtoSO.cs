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
        bool firstSkip = true; // ù ������ �ѱ�� ���� bool

        MonstersStatusSO monstersStatusSO = ScriptableObject.CreateInstance<MonstersStatusSO>();


        foreach (string s in allLines)
        {
            if (firstSkip)
            {
                firstSkip = false; // ù ���� ��ŵ
                continue;
            }

            string[] splitData = s.Split(",");

            if (splitData.Length != 4 ) // 4ĭ�� �ƴ� ��� ����ó��
            {
                Debug.LogError("���� 4ĭ�� �ƴ϶� ����Ұ�");
                return;
            }

            MonstersStatusSO.Monsters monsters = new MonstersStatusSO.Monsters();
            // �ʱ�ȭ�ε� ������ �þ�ų� �پ� �� ���� �����ؾ� ��
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
