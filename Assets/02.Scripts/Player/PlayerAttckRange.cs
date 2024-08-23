using UnityEngine;

public class PlayerAttckRange : MonoBehaviour
{
    [SerializeField] PlayerAttck playerAttck;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            playerAttck.isAttck = true; // 트리거 시작
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            playerAttck.isAttck = false; // 트리거 초기화
        }
    }
}
