using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    MonstersStatusSO monstersStatusSO;
    Animator animator;

    public string monsterName; // 몬스터 이름
    public string monsterGrade; // 몬스터 등급
    public float monsterSpeed; // 몬스터 스피드
    public int monsterHealth; // 몬스터 체력
    public float curmonsterHealth; // 몬스터 현재 체력
    public bool isAlive; // 살아있는지 체크
    public bool isDead; // 죽었을때 한번만 실행
    bool stop; // 플레이어에게 닿을시 멈춤

    private void Awake()
    {
        monstersStatusSO = MonsterStatusParsing.Instance.monstersStatusSO;
        animator = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        Init();
    }

    private void FixedUpdate()
    {
        if (!stop)
        {
            MonsterMove();
            //공격 기능이 있다면 공격 실행
        }
    }
    void Update()
    {
        if (!isAlive && !isDead)
        {
            isDead = true;
            animator.SetTrigger("Death");
            //죽는 애니메이션 실행
            Invoke(nameof(MonsterDestroy), 1f);
        }
    }
    void Init() // 초기화
    {
        // (Clone)을 제거한 이름을 사용
        string objectName = gameObject.name.Replace("(Clone)", "").Trim().ToLower();

        for (int i = 0; monstersStatusSO.monsters.Count > i; i++)
        {
            // 파싱된 이름도 공백을 제거하고 소문자로 변환
            string parsedName = monstersStatusSO.monsters[i].name.Trim().ToLower();

            //몬스터 오브젝트 이름이 같으면 해당 정보로 초기화
            if (objectName == parsedName)
            {
                monsterName = monstersStatusSO.monsters[i].name;
                monsterGrade = monstersStatusSO.monsters[i].grade;
                monsterSpeed = monstersStatusSO.monsters[i].speed;
                monsterHealth = monstersStatusSO.monsters[i].health;
                curmonsterHealth = monsterHealth;
                isAlive = true;
                isDead = false;
                stop = false;
                break;
            }
        }
    }
    void MonsterMove()
    {
        transform.Translate(Vector3.left * monsterSpeed * Time.deltaTime);
    }
    void MonsterDestroy()
    {
        MonsterSpawnManager.Instance.MonsterDead();
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stop = true;
            animator.SetBool("Idle", true);
            // 여기에 플레이어 공격 코루틴 작성
        }
    }
}
