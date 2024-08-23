using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonstersSpawn", menuName = "Assets/MonstersSpawn", order = 1)]
public class MonstersSpawnSO : ScriptableObject
{
    [Serializable]
    public struct MonstersSpawn
    {
        [Header("Monsters Status")]
        public string name; // 몬스터 이름
        public GameObject frefab; // 몬스터 등급
    }
    public List<MonstersSpawn> monstersSpawn = new List<MonstersSpawn>();
}
