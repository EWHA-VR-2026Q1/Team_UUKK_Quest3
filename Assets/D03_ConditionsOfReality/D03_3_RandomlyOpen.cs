using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D03_3_RandomlyOpen : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(Random.value > 0.5f)
        {
            transform.Translate(Vector3.up * 3);
        }
    }
}
