using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIndiaInteraction : MonoBehaviour
{
    public GameObject targetObject;

    public void ToggleTarget()
    {
        targetObject.SetActive(!targetObject.activeSelf);
    }
}
