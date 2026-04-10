using UnityEngine;

public class ScreenInteractable : MonoBehaviour, IRayInteractable
{
    public ColorBlindEffect effect;

    public void OnRayEnter() { }

    public void OnRayStay() { }

    public void OnRayExit() { }

    public void OnRayClick()
    {
        Debug.Log("클릭됨"); // 이거 찍히는지 확인
        effect.isActive = !effect.isActive;
    }
}