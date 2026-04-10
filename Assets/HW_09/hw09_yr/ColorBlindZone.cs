using UnityEngine;

public class ColorBlindZone : MonoBehaviour
{
    public ColorBlindEffect effect; 
    public float radius = 5f;

    void Update()
    {
        float dist = Vector3.Distance(transform.position, Camera.main.transform.position);
        effect.isActive = (dist <= radius); 
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}