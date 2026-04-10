using UnityEngine;

public class ColorBlindZone : MonoBehaviour
{
    public GameObject filterImage; // Canvas 안의 Image 오브젝트 연결
    public float radius = 5f;      // 반경

    void Update()
    {
        float dist = Vector3.Distance(transform.position, Camera.main.transform.position);
        filterImage.SetActive(dist <= radius);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}