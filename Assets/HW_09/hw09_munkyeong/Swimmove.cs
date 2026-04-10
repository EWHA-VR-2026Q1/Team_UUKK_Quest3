using UnityEngine;
using UnityEngine.InputSystem; // 신형 입력 시스템 라이브러리 추가

public class SwimMove : MonoBehaviour
{
    public float swimSpeed = 3.0f;
    public Transform cameraTransform;

    void Update()
    {
        // Keyboard.current를 사용하는 신형 방식
        Vector2 input = Vector2.zero;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) input.y = 1;
            if (Keyboard.current.sKey.isPressed) input.y = -1;
            if (Keyboard.current.aKey.isPressed) input.x = -1;
            if (Keyboard.current.dKey.isPressed) input.x = 1;
        }

        if (input != Vector2.zero)
        {
            Vector3 dir = (cameraTransform.forward * input.y) + (cameraTransform.right * input.x);
            transform.Translate(dir * swimSpeed * Time.deltaTime, Space.World);
        }
    }
}