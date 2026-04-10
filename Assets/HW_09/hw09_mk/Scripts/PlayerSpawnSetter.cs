using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerSpawnSetter : MonoBehaviour
{
    public Transform spawnPoint;

    void Start()
    {
        if (spawnPoint == null) return;

        CharacterController cc = GetComponent<CharacterController>();

        cc.enabled = false;
        transform.position = spawnPoint.position + Vector3.up * 0.2f;
        transform.rotation = spawnPoint.rotation;
        cc.enabled = true;
    }
}