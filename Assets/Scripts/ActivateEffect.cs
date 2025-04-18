using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEffect : MonoBehaviour
{
    [Header("Target GameObject To Activate")]
    public GameObject objectToActivate;

    [Header("Target Transform Where It Should Be Activated")]
    public Transform targetTransform;

    [Header("GameObjects To Deactivate")]
    public GameObject[] objectsToDeactivate;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ActivateObjectAtPosition()
    {
        if (objectToActivate != null && targetTransform != null)
        {
            // Move it to the target position & rotation
            objectToActivate.transform.position = targetTransform.position;
            objectToActivate.transform.rotation = targetTransform.rotation;

            // Activate the GameObject
            objectToActivate.SetActive(true);

            // Deactivate all other specified GameObjects
            if (objectsToDeactivate != null && objectsToDeactivate.Length > 0)
            {
                foreach (GameObject obj in objectsToDeactivate)
                {
                    if (obj != null)
                    {
                        obj.SetActive(false);
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("Object or Target Transform is not assigned.");
        }
    }
}
