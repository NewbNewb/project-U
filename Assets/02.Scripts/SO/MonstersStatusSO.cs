using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monsters", menuName = "Assets/Monster", order = 0)]
public class MonstersStatusSO : ScriptableObject
{
    [Serializable]
    public struct Monsters
    {
        [Header("Monsters Status")]
        public string name; // 몬스터 이름
        public string grade; // 몬스터 등급
        public float speed; // 몬스터 스피드
        public int health; // 몬스터 체력
    }
    public List<Monsters> monsters = new List<Monsters>();
}
