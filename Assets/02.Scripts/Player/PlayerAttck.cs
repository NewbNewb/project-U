using System.Collections;
using UnityEngine;

public class PlayerAttck : MonoBehaviour
{
    PlayerStatus playerStatus;
    MonsterStatus monster;
    MonsterHPBar monsterHPBar;
    Animator playerAnimator;
    [SerializeField] GameObject attckObj;

    public bool isAttck = false; // 공격 상태 플래그
    public LayerMask monsterLayer; //레이어 선택
    float findRange; // 몬스터 감지 범위
    bool hasDetected = false; // 감지 상태 플래그


    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
        playerAnimator = GetComponentInChildren<Animator>();
        findRange = 0.52f;
    }
    void Update()
    {
        MonsterDetect();
    }

    void MonsterDetect() //몬스터 감지
    {
        if (!hasDetected)
        {
            // 닿은 대상 레이어가 몬스터일시
            Collider2D collision = Physics2D.OverlapCircle(transform.position, findRange, monsterLayer);
            if (collision != null)
            {
                //몬스터 정보 가져오기
                monster = collision.gameObject.GetComponent<MonsterStatus>();
                monsterHPBar = collision.gameObject.GetComponent<MonsterHPBar>();

                //캐릭터 애니메이션 관련
                playerAnimator.SetBool("Walk", false);
                playerAnimator.SetBool("Idle", true);

                //감지 상태 플래그
                hasDetected = true;

                //공격 시작
                StartCoroutine(Attck());
            }
        }
    }
    void OnDrawGizmos() // 감지 범위 그리기
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, findRange);
    }

    IEnumerator Attck() // 공격 코루틴 반복
    {
        //몬스터 체력이 0이 될때까지
        while (monster != null && monster.curmonsterHealth >= 0)
        {
            // 공격 관련 로직
            if (!isAttck)
            {
                attckObj.SetActive(true);
                PlayerRandomAttck(); // 공격 실행
                monsterHPBar.CheckHp(); // 몬스터 체력바 갱신
                attckObj.SetActive(false);
            }

            //몬스터가 죽으면 코루틴 종료
            if (monster.curmonsterHealth <= 0)
            {
                monster.isAlive = false;
                yield return new WaitForSeconds(1f);
                playerAnimator.SetBool("Walk", true);
                playerAnimator.SetBool("Idle", false);
                hasDetected = false;
                yield break;
            }
            // 플레이어 공격속도에 맞춰 공격
            yield return new WaitForSeconds(playerStatus.attckSpeed);
            
        }
    }
    public void PlayerRandomAttck() // 플레이어 모션 랜덤 + 데미지
    {
        int rnd = Random.Range(0, 3);
        switch (rnd)
        {
            case 0:
                playerAnimator.SetTrigger("Attack01");
                monster.curmonsterHealth -= playerStatus.attckDamage * 0.5f;
                break;
            case 1:
                playerAnimator.SetTrigger("Attack02");
                monster.curmonsterHealth -= playerStatus.attckDamage;
                break;
            case 2:
                playerAnimator.SetTrigger("Attack03");
                monster.curmonsterHealth -= playerStatus.attckDamage * 1.5f;
                break;
        }
    }
}
