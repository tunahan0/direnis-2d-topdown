using UnityEngine;

public class DelayedObject : MonoBehaviour
{
    public float delayTime = 30f; // 30 saniye gecikme
    private Collider2D col;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Baþta görünmesin ve çarpýþmasýn
        if (spriteRenderer != null) spriteRenderer.enabled = false;
        if (col != null) col.enabled = false;

        // Belirli süre sonra etkinleþtir
        Invoke(nameof(ActivateObject), delayTime);
    }

    void ActivateObject()
    {
        if (spriteRenderer != null) spriteRenderer.enabled = true;
        if (col != null) col.enabled = true;
    }
}
