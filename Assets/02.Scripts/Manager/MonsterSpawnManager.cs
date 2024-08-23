using UnityEngine;

public class MonsterSpawnManager : Singleton<MonsterSpawnManager>
{
    int monsterNumber;
    public MonstersSpawnSO monstersSpawnSO;
    [SerializeField] GameObject monsterobj;
    [SerializeField] MonsterStatus monsterStatus;

    void Start()
    {
        monsterNumber = 0;
    }

    void Update()
    {
        if (monsterobj == null)
        {
            MonsterSpawn();
        }
    }
    void MonsterSpawn()
    {
        monsterobj = monstersSpawnSO.monstersSpawn[monsterNumber].frefab;
        GameObject go = Instantiate(monsterobj, new Vector3(1.73f, 0, 0), Quaternion.identity);
        monsterStatus = go.GetComponent<MonsterStatus>();
    }
    public void MonsterDead()
    {
        monsterobj = null;
        monsterNumber++;

        // 순서대로 반복
        if (monsterNumber >= monstersSpawnSO.monstersSpawn.Count)
        {
            monsterNumber = 0;
        }
    }
}
