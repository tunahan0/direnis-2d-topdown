using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 0.125f;

    [Header("Kamera sýnýrlarýnda boþluk")]
    [SerializeField] float edgeOffset = 1f;

    private Vector2 minBounds;
    private Vector2 maxBounds;
    private float camHalfWidth;
    private float camHalfHeight;

    private void Start()
    {
        camHalfHeight = Camera.main.orthographicSize;
        camHalfWidth = camHalfHeight * Camera.main.aspect;

        // floor nesnesini bul ve sýnýrlarýný al
        SpriteRenderer bg = GameObject.Find("floor").GetComponent<SpriteRenderer>();
        Bounds bounds = bg.bounds;

        minBounds = bounds.min;
        maxBounds = bounds.max;
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector2 desiredPosition = target.position;
        Vector2 smoothedPosition = Vector2.Lerp((Vector2)transform.position, desiredPosition, smoothSpeed);

        float clampedX = Mathf.Clamp(
            smoothedPosition.x,
            minBounds.x + camHalfWidth - edgeOffset,
            maxBounds.x - camHalfWidth + edgeOffset);

        float clampedY = Mathf.Clamp(
            smoothedPosition.y,
            minBounds.y + camHalfHeight - edgeOffset,
            maxBounds.y - camHalfHeight + edgeOffset);

        transform.position = new Vector3(clampedX, clampedY, -10f);
    }
}
