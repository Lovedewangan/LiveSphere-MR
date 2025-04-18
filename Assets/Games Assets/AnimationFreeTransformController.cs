/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using M;
using Oculus.Interaction;

public class AnimationFreeTransformController : MonoBehaviour
{
    // Reference to the GameObject that has the component you want to toggle
    public GameObject targetObject;

    // The specific component type you want to toggle (assign in inspector)
    public MonoBehaviour componentToToggle;

    // Delay before re-enabling the component
    public float reEnableDelay = 2.0f;

    // Reference to the OVRGrabbable component
    private GrabInteractable metaGrabInteractable;

    // Coroutine reference for delayed enabling
    private Coroutine reEnableCoroutine;

    void Start()
    {
        // Get the GrabInteractable component on this object
        metaGrabInteractable = GetComponent<GrabInteractable>();

        if (metaGrabInteractable == null)
        {
            Debug.LogError("No GrabInteractable component found on this GameObject!");
            return;
        }

        // Subscribe to GrabInteractable events
        metaGrabInteractable.WhenGrabbed.AddListener(OnGrabbed);
        metaGrabInteractable.WhenReleased.AddListener(OnReleased);
    }

    void OnGrabbed(GrabbableArgs args)
    {
        if (componentToToggle != null)
        {
            // Disable the component when grabbed
            componentToToggle.enabled = false;

            // If there was a pending re-enable, cancel it
            if (reEnableCoroutine != null)
            {
                StopCoroutine(reEnableCoroutine);
                reEnableCoroutine = null;
            }
        }
        else
        {
            Debug.LogWarning("Component to toggle not assigned!");
        }
    }

    void OnReleased(GrabbableArgs args)
    {
        if (componentToToggle != null)
        {
            // Start coroutine to re-enable the component after delay
            reEnableCoroutine = StartCoroutine(ReEnableAfterDelay());
        }
    }

    IEnumerator ReEnableAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(reEnableDelay);

        // Re-enable the component
        componentToToggle.enabled = true;

        // Clear the coroutine reference
        reEnableCoroutine = null;
    }

    void OnDestroy()
    {
        // Unsubscribe from events when this object is destroyed
        if (metaGrabInteractable != null)
        {
            metaGrabInteractable.WhenGrabbed.RemoveListener(OnGrabbed);
            metaGrabInteractable.WhenReleased.RemoveListener(OnReleased);
        }
    }
}
*/