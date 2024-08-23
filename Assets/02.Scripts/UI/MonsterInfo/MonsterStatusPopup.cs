using TMPro;
using UnityEngine;

public class MonsterStatusPopup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI monsterName;
    [SerializeField] TextMeshProUGUI monsterGrade;
    [SerializeField] TextMeshProUGUI monsterSpeed;
    [SerializeField] TextMeshProUGUI monsterHealth;

    public void MonsterStatusPopupSet(GameObject go)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        MonsterStatus monsterStatus = go.GetComponent<MonsterStatus>();
        monsterName.text = monsterStatus.monsterName;
        monsterGrade.text = monsterStatus.monsterGrade;
        monsterSpeed.text = monsterStatus.monsterSpeed.ToString();
        monsterHealth.text = monsterStatus.monsterHealth.ToString();
    }
}
