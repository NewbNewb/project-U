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
        public string name; // ���� �̸�
        public string grade; // ���� ���
        public float speed; // ���� ���ǵ�
        public int health; // ���� ü��
    }
    public List<Monsters> monsters = new List<Monsters>();
}
