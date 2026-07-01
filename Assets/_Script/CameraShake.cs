using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    private ThirdPersonCamera tpCamera;

    void Awake()
    {
        Instance = this;
        tpCamera = GetComponent<ThirdPersonCamera>();
    }

    public void Shake(float duration = 0.15f, float magnitude = 0.15f)
    {
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine(duration, magnitude));
    }

    IEnumerator ShakeRoutine(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float xOffset = Random.Range(-1f, 1f) * magnitude;
            float yOffset = Random.Range(-1f, 1f) * magnitude;

            tpCamera.ApplyShakeOffset(new Vector3(xOffset, yOffset, 0f));

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        tpCamera.ApplyShakeOffset(Vector3.zero); 
    }
}