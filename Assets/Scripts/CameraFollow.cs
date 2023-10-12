using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; 
    public float orthographicSize; 

    private float minX = -10f;
    private float maxX = 10f;
    private float minY = -10f;
    private float maxY = 10f;

    void Start()
    {
        // Установите начальное значение размера ортографической камеры.
        Camera.main.orthographicSize = orthographicSize;
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = desiredPosition;

        float camHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float camHalfHeight = Camera.main.orthographicSize;

        smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minX + camHalfWidth, maxX - camHalfWidth);
        smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minY + camHalfHeight, maxY - camHalfHeight);

        transform.position = smoothedPosition;
    }
}






