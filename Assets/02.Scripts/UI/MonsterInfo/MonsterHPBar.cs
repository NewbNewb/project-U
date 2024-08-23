using UnityEngine;
using UnityEngine.UI;

public class MonsterHPBar : MonoBehaviour
{
    MonsterStatus monsterStatus;
    Slider HpBarSlider;

    void Start()
    {
        monsterStatus = GetComponent<MonsterStatus>();
        HpBarSlider = GetComponentInChildren<Slider>();
        Init();
    }
    void Init()
    {
        HpBarSlider.minValue = 0;
        HpBarSlider.maxValue = monsterStatus.monsterHealth;
        HpBarSlider.value = monsterStatus.curmonsterHealth;
    }

    public void CheckHp() //*HP 갱신
    {
        HpBarSlider.value = monsterStatus.curmonsterHealth;
    }
}
