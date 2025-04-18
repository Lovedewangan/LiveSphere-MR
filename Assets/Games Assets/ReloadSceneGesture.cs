using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneGesture : MonoBehaviour
{
    void Update()
    {
        // Check if menu button is pressed
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            // Execute your feature here
            ExecuteYourFeature();
        }
    }

    void ExecuteYourFeature()
    {
        // Your feature implementation
        SceneManager.LoadScene(0);
        Debug.Log("Menu button pressed - feature activated!");
    }
}
