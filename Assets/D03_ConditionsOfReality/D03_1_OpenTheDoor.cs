using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D03_1_OpenTheDoor : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.Translate(Vector3.up * 3);
    }
}
