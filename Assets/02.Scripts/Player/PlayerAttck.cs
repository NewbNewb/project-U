using System.Collections;
using UnityEngine;

public class PlayerAttck : MonoBehaviour
{
    PlayerStatus playerStatus;
    MonsterStatus monster;
    MonsterHPBar monsterHPBar;
    Animator playerAnimator;

    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    IEnumerator Attck() // 공격 코루틴 반복
    {
        //몬스터 체력이 0이 될때까지
        while (monster.curmonsterHealth >= 0)
        {
            if (gameObject == null) // 예외처리
                yield break;

            //플레이어 공격력 만큼 체력 감소
            PlayerRandomAttck();
            monsterHPBar.CheckHp();
            
            //몬스터가 죽으면 코루틴 종료
            if (monster.curmonsterHealth <= 0)
            {
                monster.isAlive = false;
                Invoke(nameof(PlayerAni), 1f);
                yield break;
            }
            // 플레이어 공격속도에 맞춰 공격
            yield return new WaitForSeconds(playerStatus.attckSpeed);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 닿은 대상 태그가 몬스터일시 전투시작
        if (collision.gameObject.CompareTag("Monster"))
        {
            monster = collision.gameObject.GetComponent<MonsterStatus>();
            monsterHPBar = collision.gameObject.GetComponent<MonsterHPBar>();
            playerAnimator.SetBool("Walk", false);
            playerAnimator.SetBool("Idle", true);
            StartCoroutine(Attck());
        }
    }
    void PlayerAni()
    {
        playerAnimator.SetBool("Walk", true);
        playerAnimator.SetBool("Idle", false);
    }
    void PlayerRandomAttck()
    {
        int rnd = Random.Range(0, 3);
        switch(rnd)
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
