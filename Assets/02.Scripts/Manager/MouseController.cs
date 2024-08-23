using UnityEngine;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour
{
    [SerializeField] Camera m_camera;
    [SerializeField] MonsterStatusPopup monsterStatusPopup;

    void Start()
    {
        if (m_camera == null)
        {
            m_camera = Camera.main; // 주 카메라가 자동으로 할당되도록 설정
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RayStart();
        }
    }

    void RayStart()
    {
        // 마우스 위치 구하기
        Vector2 mousePosition = m_camera.ScreenToWorldPoint(Input.mousePosition);

        // UI에 겹치지 않게 레이 발사
        if (EventSystem.current.IsPointerOverGameObject(0))
        {
            return;
        }

        // 레이캐스트 히트 정보 가져오기
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)  // 레이캐스트 실행
        {
            GameObject hitObject = hit.collider.gameObject; // 맞은 오브젝트를 가져옴
            if (hitObject.tag == "Monster")
            {
                isMonster(hitObject); // 몬스터일시 실행되는 메소드
            }
        }
    }
    void isMonster(GameObject go)
    {
        monsterStatusPopup.MonsterStatusPopupSet(go);
        // 몬스터 터치 관련 추가되는 사항이 있다면 여기서 추가
    }
}
