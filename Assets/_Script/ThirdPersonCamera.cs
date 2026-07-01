using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 6f;
    public float height = 2.5f;
    public float mouseSensitivity = 3f;
    public float minPitch = 10f;
    public float maxPitch = 60f;

    [Header("Collision")]
    public LayerMask collisionMask = ~0; 
    public float collisionBuffer = 0.3f; 
    public float minDistance = 1.5f;   

    float yaw = 0f;
    float pitch = 30f;
    Vector3 shakeOffset = Vector3.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (target == null) return;

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 pivotPoint = target.position + Vector3.up * height;
        Vector3 desiredCameraPos = pivotPoint - (rotation * Vector3.forward * distance);

        float finalDistance = distance;

        RaycastHit hit;
        if (Physics.Linecast(pivotPoint, desiredCameraPos, out hit, collisionMask, QueryTriggerInteraction.Ignore))
        {
            finalDistance = Mathf.Clamp(hit.distance - collisionBuffer, minDistance, distance);
        }

        Vector3 finalPosition = pivotPoint - (rotation * Vector3.forward * finalDistance);

        transform.position = finalPosition + shakeOffset;
        transform.LookAt(target.position + Vector3.up * 1f);
    }

    public void ApplyShakeOffset(Vector3 offset)
    {
        shakeOffset = offset;
    }
    
    public Vector3 GetFlatForward()
    {
        Vector3 forward = transform.forward;
        forward.y = 0f;
        return forward.normalized;
    }

    public Vector3 GetFlatRight()
    {
        Vector3 right = transform.right;
        right.y = 0f;
        return right.normalized;
    }
}