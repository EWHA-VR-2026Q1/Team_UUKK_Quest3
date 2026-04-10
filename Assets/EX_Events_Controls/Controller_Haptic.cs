using UnityEngine;
using System.Collections;

public class Controller_Haptic : MonoBehaviour
{
    public OVRInput.Controller controllerType = OVRInput.Controller.LTouch;

    [Header("Haptic Settings")]
    public float enterAmplitude = 0.1f;
    public float enterDuration = 0.05f;
    [Range(1, 5)] public int enterCount = 1; // 진동 횟수 추가

    public float clickAmplitude = 0.5f;
    public float clickDuration = 0.1f;
    [Range(1, 5)] public int clickCount = 1; // 진동 횟수 추가

    [Header("Interval Settings")]
    public float pulseInterval = 0.05f; // 진동 사이의 간격 시간

    // 인스펙터의 UnityEvent용 함수
    public void TriggerEnterHaptic() => StartCoroutine(PlayHaptic(enterAmplitude, enterDuration, enterCount));
    public void TriggerClickHaptic() => StartCoroutine(PlayHaptic(clickAmplitude, clickDuration, clickCount));

    private IEnumerator PlayHaptic(float amp, float duration, int count)
    {
        for (int i = 0; i < count; i++)
        {
            // 1. 진동 시작
            OVRInput.SetControllerVibration(1.0f, amp, controllerType);

            // 2. 진동 유지 시간
            yield return new WaitForSeconds(duration);

            // 3. 진동 정지
            OVRInput.SetControllerVibration(0, 0, controllerType);

            // 4. 마지막 진동이 아니라면 간격만큼 대기
            if (i < count - 1)
            {
                yield return new WaitForSeconds(pulseInterval);
            }
        }
    }
}