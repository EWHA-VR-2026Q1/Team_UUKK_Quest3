using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int totalArrows;
    private int collected = 0;

    public Renderer exitArrowRenderer;
    public Material lockedMaterial;
    public Material unlockedMaterial;
    public Transform teleportTarget;

    private bool unlocked = false;

    void Start()
    {
        if (exitArrowRenderer != null && lockedMaterial != null)
            exitArrowRenderer.material = lockedMaterial;

        Debug.Log("LevelManager 시작됨. totalArrows = " + totalArrows);
    }

    public void CollectArrow()
    {
        collected++;
        Debug.Log($"수집: {collected}/{totalArrows}");

        if (collected >= totalArrows)
        {
            unlocked = true;
            Debug.Log("출구 열림");

            if (exitArrowRenderer != null && unlockedMaterial != null)
                exitArrowRenderer.material = unlockedMaterial;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("출구 트리거 감지: " + other.name + " / unlocked = " + unlocked);

        if (!unlocked) return;
        if (!other.CompareTag("Player")) return;

        if (teleportTarget == null)
        {
            Debug.LogError("teleportTarget 연결 안 됨!");
            return;
        }

        CharacterController cc = other.GetComponentInParent<CharacterController>();

        if (cc != null)
        {
            Vector3 targetPos = teleportTarget.position + Vector3.up * 0.2f;

            Debug.Log("이동 전 플레이어 루트 위치: " + cc.transform.position);
            Debug.Log("teleportTarget 월드 위치: " + teleportTarget.position);
            Debug.Log("실제 이동 위치: " + targetPos);

            cc.enabled = false;
            cc.transform.position = targetPos;
            cc.transform.rotation = teleportTarget.rotation;
            cc.enabled = true;

            Debug.Log("이동 후 플레이어 루트 위치: " + cc.transform.position);
        }
        else
        {
            Debug.LogError("CharacterController를 부모에서 찾지 못함");
        }
    }
}