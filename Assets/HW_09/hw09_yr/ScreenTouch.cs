using UnityEngine;
// 1. 새로운 입력 시스템 네임스페이스 추가
using UnityEngine.InputSystem;

public class ScreenTouch : MonoBehaviour
{
    public ColorBlindEffect effect;

    void Update()
    {
        // 2. 마우스 왼쪽 버튼 클릭 또는 터치 발생 확인
        bool isClick = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;
        bool isTouch = Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame;

        if (isClick || isTouch)
        {
            // 3. 현재 마우스 또는 터치 위치 가져오기
            Vector2 screenPosition = Vector2.zero;
            if (isClick) screenPosition = Mouse.current.position.ReadValue();
            else if (isTouch) screenPosition = Touchscreen.current.primaryTouch.position.ReadValue();

            // 4. 레이캐스트 로직
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    effect.isActive = !effect.isActive;
                }
            }
        }
    }
}