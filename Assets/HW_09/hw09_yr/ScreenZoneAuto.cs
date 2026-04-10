using UnityEngine;

public class ScreenZoneAuto : MonoBehaviour
{
    public ColorBlindEffect effect;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OVRPlayerController" || other.gameObject.tag == "Player")
        {
            effect.isActive = true;
            Debug.Log("존 진입 - 필터 ON");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "OVRPlayerController" || other.gameObject.tag == "Player")
        {
            effect.isActive = false;
            Debug.Log("존 이탈 - 필터 OFF");
        }
    }
}