using UnityEngine;

public class ScreenTouch : MonoBehaviour
{
    public ColorBlindEffect effect;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // PC 테스트용
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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