using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class D03_PlayerController_Physics : MonoBehaviour
{
    CharacterController character;

    Vector3 velocity;
    Vector3 inputDir;

    Transform cameraPivot;

    public float walkSpeed = 1.5f;   // m/s (현실 걷기 속도)
    public float runSpeed = 3.5f;    // m/s (현실 달리기 속도보다 느리나 디지털 멀미 예방을 위해 제한함)
    public float friction = 0.9f;    // 마찰로 인해 남는 속도의 비율 (1.0 = 마찰 없음, 0.7 = 강한 마찰)

    public float gravity = -9.81f;   // 중력 가속도
    public float jumpHeight = 0.5f;  // 점프 높이

    public float mouseSensitivity = 100f;

    float yaw; // y 축 회전
    float pitch; // x 축 회전
    // https://en.wikipedia.org/wiki/Aircraft_principal_axes

    void Start()
    {
        character = GetComponent<CharacterController>();
        cameraPivot = transform.GetChild(0);

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleLook();
        HandleMove();
        ApplyGravity();
    }

    // ---------------------
    // 카메라 회전 처리
    // ---------------------

    void HandleLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        yaw += mouseX;   // y 축 회전
        pitch -= mouseY; // x 축 회전

        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.rotation = Quaternion.Euler(0, yaw, 0);
        cameraPivot.localRotation = Quaternion.Euler(pitch, 0, 0);
    }

    // ---------------------
    // 이동 처리
    // ---------------------

    void HandleMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        inputDir = transform.forward * v + transform.right * h;

        if (inputDir.sqrMagnitude > 1)
            inputDir.Normalize();

        bool running = Input.GetKey(KeyCode.LeftShift);
        float speed = running ? runSpeed : walkSpeed;

        if (inputDir.magnitude > 0)
        {
            // 입력이 있을 때 → 목표 속도
            velocity.x = inputDir.x * speed;
            velocity.z = inputDir.z * speed;
        }
        else
        {
            // 입력이 없을 때 → 마찰 적용
            velocity.x *= friction;
            velocity.z *= friction;
        }

        if (character.isGrounded)
        {
            if (velocity.y < 0) velocity.y = -2f; // 지면 접촉을 위해 낙하 속도를 작은 음수로 유지

            if (Input.GetKeyDown(KeyCode.Space))
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // v² = 2gh (v = 초기 점프 속도, g = 중력, h = 점프 높이)
        }

        character.Move(velocity * Time.deltaTime);
    }

    // ---------------------
    // 중력 처리
    // ---------------------

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
    }
}