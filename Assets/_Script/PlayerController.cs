using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float acceleration = 30f;
    public float maxSpeed = 10f;
    public float rotationSmoothing = 10f;

    [Header("Dash")]
    public float dashForce = 15f;
    public float dashCooldown = 5f;
    private float dashCooldownTimer = 0f;

    [Header("Camera Reference")]
    public ThirdPersonCamera tpCamera; 

    Rigidbody rb;
    Vector3 moveDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameState.Instance != null && GameState.Instance.isGameOver) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 camForward = tpCamera.GetFlatForward();
        Vector3 camRight = tpCamera.GetFlatRight();

        moveDirection = (camForward * v + camRight * h);
        if (moveDirection.magnitude > 1f) moveDirection.Normalize();

        dashCooldownTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && UpgradeManager.Instance != null &&
            UpgradeManager.Instance.hasDashUpgrade && dashCooldownTimer <= 0f)
        {
            Vector3 dashDir = moveDirection.magnitude > 0.1f ? moveDirection : transform.forward;
            rb.AddForce(dashDir * dashForce, ForceMode.VelocityChange);
            dashCooldownTimer = dashCooldown;
        }
    }

    void FixedUpdate()
    {
        if (GameState.Instance != null && GameState.Instance.isGameOver) return;

        if (moveDirection.magnitude > 0.1f)
        {
            rb.AddForce(moveDirection * acceleration, ForceMode.Acceleration);

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1f - Mathf.Exp(-rotationSmoothing * Time.fixedDeltaTime));
        }

        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (flatVel.magnitude > maxSpeed)
        {
            Vector3 limited = flatVel.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(limited.x, rb.linearVelocity.y, limited.z);
        }
    }
}