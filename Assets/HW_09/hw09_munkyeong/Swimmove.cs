using UnityEngine;
using UnityEngine.InputSystem; // New Input System 라이브러리

public class SwimMove : MonoBehaviour
{
    public float swimSpeed = 3.0f;
    public Transform cameraTransform;

    void Update()
    {
        Vector2 input = Vector2.zero;

        // 1. 키보드 입력 체크 (WASD)
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) input.y += 1;
            if (Keyboard.current.sKey.isPressed) input.y -= 1;
            if (Keyboard.current.aKey.isPressed) input.x -= 1;
            if (Keyboard.current.dKey.isPressed) input.x += 1;
        }

        // 2. 조이스틱 입력 체크 (추가!)
        // New Input System에서는 VR 조이스틱도 'Gamepad' 범주에 들어갑니다.
        if (Gamepad.current != null)
        {
            // 왼쪽 조이스틱 값을 읽어서 기존 input에 더해줌
            input += Gamepad.current.leftStick.ReadValue();
        }

        // 3. 이동 실행 (이하 동일)
        if (input != Vector2.zero)
        {
            // 대각선 이동 시 빨라지지 않게 정규화(Normalize) 해주면 더 좋습니다.
            if (input.magnitude > 1) input.Normalize();

            Vector3 dir = (cameraTransform.forward * input.y) + (cameraTransform.right * input.x);
            transform.Translate(dir * swimSpeed * Time.deltaTime, Space.World);
        }
    }
}