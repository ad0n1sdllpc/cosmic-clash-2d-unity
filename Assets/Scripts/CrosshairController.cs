using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public GameObject mouseCrosshair; // Reference to the mouse crosshair object
    public GameObject gamepadCrosshair; // Reference to the gamepad crosshair object

    public float speed = 5f; // Adjust the speed of crosshair movement
    public float maxDistance = 5f; // Maximum distance from the center

    void Update()
    {
        if (Input.GetJoystickNames().Length > 0)
        {
            // Gamepad input
            MoveCrosshairWithJoystick();
        }
        else
        {
            // Mouse input
            MoveCrosshairWithMouse();
        }
    }

    void MoveCrosshairWithJoystick()
    {
        // Get input from gamepad
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        transform.position += movement;

        // Clamp position within a circle
        transform.position = Vector3.ClampMagnitude(transform.position, maxDistance);

        // Update crosshair position
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        transform.position = new Vector3(screenPosition.x, screenPosition.y, 0f);

        // Enable gamepad crosshair and disable mouse crosshair
        gamepadCrosshair.SetActive(true);
        mouseCrosshair.SetActive(false);
    }

    void MoveCrosshairWithMouse()
    {
        // Get mouse position
        Vector3 mousePosition = Input.mousePosition;

        // Convert mouse position to world space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0f;

        // Set crosshair position
        transform.position = worldPosition;

        // Enable mouse crosshair and disable gamepad crosshair
        mouseCrosshair.SetActive(true);
        gamepadCrosshair.SetActive(false);
    }
}
