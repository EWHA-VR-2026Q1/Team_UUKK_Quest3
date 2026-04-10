using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class D03_PlayerController : MonoBehaviour
{
    [Header("Movement")]
    //public bool isMovable = true;
    public float moveSpeed = 6.7f; // 100M를15초에 뛰는 속도
    public float mouseSensitivity = 2f;
    Vector3 Velocity, Acceleration;
    Vector3 Gravity = new Vector3(0, -9.81f, 0);
    Vector3 JumpHeight = new Vector3(0, 2f, 0);
    float friction = 0.9f; // 1보다 크거나 같아야 함. 클수록 마찰 커짐

    [Header("Jump Settings")]
    //public float jumpHeight = 1.5f;

    [Header("Ground Check")]
    public Transform groundCheck;        // 캐릭터 발밑에 위치한 빈 오브젝트
    public float groundDistance = 0.6f;  // 체크 구 반경
    public LayerMask groundMask;         // Ground 레이어만 체크

    private CharacterController controller;
    private Camera playerCamera;
    private float yVelocity;
    private float xRotation;
    private bool isGrounded;
    float horizontal, vertical;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked; // 마우스 숨기고 고정
        print(groundMask.ToString());
        if (groundMask == 0) // 0 = Nothing
        {
            groundMask = LayerMask.NameToLayer("Ground");
        }
    }

    void Update()
    {
        // GroundCheck로 접지 상태 판단
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //print($"isGrounded: {isGrounded}");

        // 중력 적용
        Vector3 Gravity = new Vector3(0, -9.81f, 0);
        AddForce(Gravity);

        // 이동 처리 (방향키)
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            float moveX = Input.GetAxis("Horizontal");
            Vector3 ForceX = transform.right * moveX * moveSpeed;
            AddForce(ForceX);
        }
        else
        {
            Vector3 Force = Vector3.zero;
            AddForce(Force); // 키에서 손을 떼면 멈춤
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            float moveZ = Input.GetAxis("Vertical");
            Vector3 ForceZ = transform.forward * moveZ * moveSpeed;
            AddForce(ForceZ);
        }
        else
        {
            Vector3 Force = Vector3.zero;
            AddForce(Force); // 키에서 손을 떼면 멈춤
        }

        // 회전 처리 (마우스)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


        // 점프 처리
        //if (isGrounded && (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space)))
        //{
        //    print("jump");
        //    yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //    // 중력 적용

        //}
        //yVelocity += gravity * Time.deltaTime;

        //controller.Move(Vector3.up * yVelocity * Time.deltaTime);

        // 물리 계산
        //float dt = Time.deltaTime;
        //Speed += Acceleration * dt;

        //// 마찰 적용
        //Speed *= friction;

        // 이동
        //controller.Move(Speed);

        // 가속 초기화
        Acceleration = Vector3.zero;
    }

    void AddForce(Vector3 force)
    {
        Acceleration = force * Time.deltaTime;
        Velocity += Acceleration;
        Velocity /= friction;
        controller.Move(Velocity);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.layer.ToString() != "Ground")
        {
            //Debug.Log("캐릭터가 충돌한 오브젝트: " + hit.gameObject.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}
