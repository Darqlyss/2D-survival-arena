
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAim : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Vector2 mouseWorldPosition =
            mainCamera.ScreenToWorldPoint(mousePosition);

        Vector2 direction =
            mouseWorldPosition - (Vector2)transform.position;

        float angle =
            Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
