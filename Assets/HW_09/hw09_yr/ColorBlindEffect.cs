using UnityEngine;

public class ColorBlindEffect : MonoBehaviour
{
    public Material material;
    public bool isActive = false;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (isActive)
            Graphics.Blit(src, dest, material);
        else
            Graphics.Blit(src, dest);
    }
}