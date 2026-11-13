
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    // Nastavení dashe
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1.5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 dashDirection;

    private float dashTimer;
    private float cooldownTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Odpočítávání času
        dashTimer -= Time.deltaTime;
        cooldownTimer -= Time.deltaTime;

        // Zjištění směru pohybu
        movement = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            movement.y += 1;

        if (Keyboard.current.sKey.isPressed)
            movement.y -= 1;

        if (Keyboard.current.dKey.isPressed)
            movement.x += 1;

        if (Keyboard.current.aKey.isPressed)
            movement.x -= 1;

        movement = movement.normalized;

        // Aktivace dashe mezerníkem
        if (Keyboard.current.spaceKey.wasPressedThisFrame
            && cooldownTimer <= 0
            && dashTimer <= 0
            && movement != Vector2.zero)
        {
            dashDirection = movement;
            dashTimer = dashDuration;
            cooldownTimer = dashCooldown;
        }
    }

    private void FixedUpdate()
    {
        // Pohyb během dashe
        if (dashTimer > 0)
        {
            rb.linearVelocity = dashDirection * dashSpeed;
        }
        else
        {
            // Normální pohyb
            rb.linearVelocity = movement * moveSpeed;
        }
    }
}
