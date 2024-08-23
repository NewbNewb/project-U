using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float attckDamage;
    public float attckSpeed;

    void Start()
    {
        Init();
    }

    void Init()
    {
        //플레이어 스텟 기본값
        attckDamage = 100;
        attckSpeed = 1.0f;
    }
}
