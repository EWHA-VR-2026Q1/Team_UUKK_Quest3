using UnityEngine;

public class ScreenTouch : MonoBehaviour
{
    public ColorBlindEffect effect;

    void Update()
    {
        // 왼손 컨트롤러 트리거 클릭
        bool isClick = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch);

        if (isClick)
        {
            // 컨트롤러 위치 + 방향으로 레이 쏘기
            Ray ray = new Ray(
                OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch),
                OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch) * Vector3.forward
            );

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    effect.isActive = !effect.isActive;
                }
            }
        }
    }
}