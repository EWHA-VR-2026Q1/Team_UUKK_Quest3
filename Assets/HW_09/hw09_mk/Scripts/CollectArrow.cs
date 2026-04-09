using UnityEngine;

public class CollectArrow : MonoBehaviour
{
    public LevelManager levelManager;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("트리거 감지: " + other.name);

        if (!other.CompareTag("Player")) return;

        Debug.Log("플레이어 접촉");

        if (levelManager != null)
        {
            levelManager.CollectArrow();
        }
        else
        {
            Debug.LogWarning("LevelManager 연결 안 됨");
        }

        gameObject.SetActive(false);
    }
}