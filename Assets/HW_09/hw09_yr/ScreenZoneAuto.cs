using UnityEngine;

public class ScreenZoneAuto : MonoBehaviour
{
    public ColorBlindEffect effect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            effect.isActive = true;
            Debug.Log("Entered zone - effect ON");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            effect.isActive = false;
            Debug.Log("Exited zone - effect OFF");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            effect.isActive = true;
        }
    }
}