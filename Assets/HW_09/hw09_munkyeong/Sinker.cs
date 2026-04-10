using UnityEngine;

public class Sinker : MonoBehaviour
{
    public float sinkSpeed = 10.0f;
    public float floorY = -1316f;

    void Update()
    {
        // 바닥보다 위에 있을 때만 실행
        if (transform.position.y > floorY)
        {
            // 다음 프레임에 이동할 위치 계산
            float nextY = transform.position.y - (sinkSpeed * Time.deltaTime);

            // 다음 위치가 바닥보다 낮아질 것 같으면 그냥 바닥에 딱 붙이기
            if (nextY <= floorY)
            {
                transform.position = new Vector3(transform.position.x, floorY, transform.position.z);
            }
            else
            {
                // 평소에는 스르륵 내려가기
                transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}