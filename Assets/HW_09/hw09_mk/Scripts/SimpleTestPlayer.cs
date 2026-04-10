using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleTestPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = -20f;
    public Transform spawnPoint;

    public float snapTurnAngle = 30f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool turnReady = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (spawnPoint != null)
        {
            controller.enabled = false;
            transform.position = spawnPoint.position;
            transform.rotation = Quaternion.identity;
            controller.enabled = true;
        }
    }

    void Update()
    {
        Move();
        SnapTurn();
    }

    void Move()
    {
        float h = 0f;
        float v = 0f;

        if (Input.GetKey(KeyCode.A)) h = -1f;
        if (Input.GetKey(KeyCode.D)) h = 1f;
        if (Input.GetKey(KeyCode.W)) v = 1f;
        if (Input.GetKey(KeyCode.S)) v = -1f;

        Vector3 move = new Vector3(h, 0f, v).normalized;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void SnapTurn()
    {
        if (Input.GetMouseButtonDown(1))
        {
            transform.Rotate(0f, snapTurnAngle, 0f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            transform.Rotate(0f, -snapTurnAngle, 0f);
        }
    }
}