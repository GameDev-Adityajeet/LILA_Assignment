using UnityEngine;

public class WaypointIndicator : MonoBehaviour
{
    [Header("References")]
    public RectTransform arrowRect;
    public Camera mainCamera;
    public RectTransform canvasRect;
    public Transform player;

    [Header("Settings")]
    public float edgePadding = 60f;

    public PlayerInteraction playerInteraction; 
    
    void LateUpdate()
    {
        Transform target = GetCurrentTarget();

        if (target == null)
        {
            arrowRect.gameObject.SetActive(false);
            return;
        }

        if (playerInteraction.isInActiveZone)
        {
            arrowRect.gameObject.SetActive(false);
            return;
        }

        arrowRect.gameObject.SetActive(true);

        Vector3 targetPos = target.position;
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(targetPos);

        bool isBehindCamera = viewportPos.z < 0f;
        bool isOnScreen = !isBehindCamera && viewportPos.x > 0f && viewportPos.x < 1f && viewportPos.y > 0f && viewportPos.y < 1f;

        if (isOnScreen)
        {
            Vector2 screenPos = new Vector2(viewportPos.x * canvasRect.rect.width, viewportPos.y * canvasRect.rect.height) - new Vector2(canvasRect.rect.width / 2f, canvasRect.rect.height / 2f);
            arrowRect.anchoredPosition = screenPos;
            arrowRect.localRotation = Quaternion.identity; 
            return;
        }

        if (isBehindCamera)
        {
            viewportPos.x = 1f - viewportPos.x;
            viewportPos.y = 1f - viewportPos.y;
        }

        Vector2 screenCenter = new Vector2(canvasRect.rect.width / 2f, canvasRect.rect.height / 2f);
        Vector2 targetScreenPos = new Vector2(viewportPos.x * canvasRect.rect.width, viewportPos.y * canvasRect.rect.height);

        Vector2 direction = (targetScreenPos - screenCenter).normalized;

        float halfWidth = canvasRect.rect.width / 2f - edgePadding;
        float halfHeight = canvasRect.rect.height / 2f - edgePadding;

        float angle = Mathf.Atan2(direction.y, direction.x);
        float cos = Mathf.Cos(angle);
        float sin = Mathf.Sin(angle);

        float scaleX = (cos != 0f) ? halfWidth / Mathf.Abs(cos) : Mathf.Infinity;
        float scaleY = (sin != 0f) ? halfHeight / Mathf.Abs(sin) : Mathf.Infinity;
        float scale = Mathf.Min(scaleX, scaleY);

        Vector2 clampedPos = direction * scale;
        arrowRect.anchoredPosition = clampedPos;

        float zRotation = angle * Mathf.Rad2Deg;
        arrowRect.localRotation = Quaternion.Euler(0f, 0f, zRotation);
    }

    Transform GetCurrentTarget()
    {
        if (DeliveryManager.Instance == null) return null;

        if (DeliveryManager.Instance.currentStage == DeliveryManager.Stage.GoToPickup)
            return DeliveryManager.Instance.currentPickup;
        else
            return DeliveryManager.Instance.currentDelivery;
    }
}