using UnityEngine;

public class ScreenTouch : MonoBehaviour
{
    public ColorBlindEffect effect;

    // 왼손 컨트롤러 Transform
    public Transform leftController;

    void Update()
    {
        // 왼손 트리거 클릭
        bool isClick = OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger);

        if (isClick)
        {
            // 컨트롤러에서 Ray 발사
            Ray ray = new Ray(
                leftController.position,
                leftController.forward
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