using UnityEngine;

public class Rotating : MonoBehaviour
{
    [Header("=====| Rotate Config |=====")]
    public float autoRotateSpeed = 0f;
    public float dragRotateSpeed = 0.3f;

    [Header("=====| Zoom Config |=====")]
    public float zoomSpeed = 1f;
    public float pinchZoomSpeed = 0.005f;
    public float minZoom = 0.5f;
    public float maxZoom = 2.5f;

    private bool isDragging;
    private Vector2 lastPointerPos;

    private Vector3 initialScale;
    private float currentZoom = 1f;

    private float lastPinchDistance;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        AutoRotate();
        HandleRotate();
        HandleZoom();
    }


    void AutoRotate()
    {
        if (!isDragging)
            transform.Rotate(Vector3.up, autoRotateSpeed * Time.deltaTime, Space.World);
    }

    void HandleRotate()
    {
        if (Input.touchCount == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                lastPointerPos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
                isDragging = false;

            if (isDragging)
            {
                Vector2 delta = (Vector2)Input.mousePosition - lastPointerPos;
                transform.Rotate(Vector3.up, -delta.x * dragRotateSpeed, Space.World);
                lastPointerPos = Input.mousePosition;
            }
        }

        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                isDragging = true;
                lastPointerPos = t.position;
            }

            if (t.phase == TouchPhase.Moved)
            {
                Vector2 delta = t.position - lastPointerPos;
                transform.Rotate(Vector3.up, -delta.x * dragRotateSpeed, Space.World);
                lastPointerPos = t.position;
            }

            if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
                isDragging = false;
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.01f)
        {
            currentZoom += scroll * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
            transform.localScale = initialScale * currentZoom;
        }

        if (Input.touchCount == 2)
        {
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            float currentDistance = Vector2.Distance(t0.position, t1.position);

            if (t1.phase == TouchPhase.Began)
            {
                lastPinchDistance = currentDistance;
            }
            else
            {
                float delta = currentDistance - lastPinchDistance;
                currentZoom += delta * pinchZoomSpeed;
                currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
                transform.localScale = initialScale * currentZoom;
                lastPinchDistance = currentDistance;
            }
        }
    }
}