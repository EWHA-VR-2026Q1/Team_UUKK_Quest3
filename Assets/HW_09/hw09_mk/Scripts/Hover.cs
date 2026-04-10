using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hover : MonoBehaviour
{
    public float height = 0.3f;   // 위아래 움직이는 높이
    public float speed = 2f;      // 움직이는 속도

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * height;
        transform.position = startPos + new Vector3(0, y, 0);
    }
}
