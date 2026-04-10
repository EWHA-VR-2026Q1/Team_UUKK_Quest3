using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerSpawnSetter : MonoBehaviour
{
    public Transform spawnPoint;

    IEnumerator Start()
    {
        if (spawnPoint == null) yield break;

        yield return null;

        CharacterController cc = GetComponent<CharacterController>();
        if (cc == null) yield break;

        cc.enabled = false;
        transform.position = spawnPoint.position + Vector3.up * 0.2f;
        cc.enabled = true;
    }
}