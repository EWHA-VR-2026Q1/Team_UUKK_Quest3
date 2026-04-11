using UnityEngine;

public class FogIncrease : MonoBehaviour
{
    public float fogSpeed = 0.001f;
    public float maxDensity = 0.05f;

    void Update()
    {
        if (RenderSettings.fogDensity < maxDensity)
        {
            RenderSettings.fogDensity += fogSpeed * Time.deltaTime;
        }
    }
}