using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeGestureRotation : MonoBehaviour
{
    public float rotationAmount = 30f;   // Degrees to rotate each time you trigger the function
    public float rotationSpeed = 2f;     // Lerp speed (the higher, the faster)

    private Quaternion targetRotation;   // Where we want the globe to rotate to
    private bool isRotating = false;     // If true, we’re currently rotating

    void Start()
    {
        // Initialize targetRotation with current rotation
        targetRotation = transform.rotation;
    }

    void Update()
    {
        // 🔧 Debug input: Use Left/Right Arrow keys to rotate manually
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Left Arrow Pressed - Rotate Left");
            RotateLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Right Arrow Pressed - Rotate Right");
            RotateRight();
        }

        // Smooth rotation towards target
        if (isRotating)
        {
            // Smoothly rotate from current to target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Stop rotating if we're close enough
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
                Debug.Log("Rotation Complete");
            }
        }
    }

    // Rotate left (positive Z-axis rotation in your case)
    public void RotateLeft()
    {
        if (isRotating) return; // Optional: prevent stacking multiple rotations at once

        // Add rotationAmount degrees around the Z-axis
        targetRotation *= Quaternion.Euler(0, rotationAmount, 0);
        isRotating = true;
    }

    // Rotate right (negative Z-axis rotation in your case)
    public void RotateRight()
    {
        if (isRotating) return; // Optional: prevent stacking multiple rotations at once

        // Subtract rotationAmount degrees around the Z-axis
        targetRotation *= Quaternion.Euler(0, -rotationAmount, 0);
        isRotating = true;
    }
}
