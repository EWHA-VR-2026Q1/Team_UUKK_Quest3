using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D03_2_DelayedOpen : MonoBehaviour
{    private void OnMouseDown()
    {
        StartCoroutine(OpenDoor());
    }

    IEnumerator OpenDoor()
    {
        print("method called");
        yield return new WaitForSeconds(0.5f);
        print("open");
        transform.Translate(Vector3.up * 3);
    }
}
