using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator animator;  // Assign this in the Inspector
    public Animator animator1;
    public string triggerName = "PlayMap"; // EXACT name of your trigger parameter in Animator
    public string triggerName1 = "PlayMap";

    private bool hasPlayed = false; // To ensure it plays only once

    // Call this method on poke interaction
    public void TriggerAnimation()
    {
        if (!hasPlayed)
        {
            
            animator.SetTrigger(triggerName); // Activates the transition
            animator1.SetTrigger(triggerName1);
            hasPlayed = true; // Prevent further triggering
        }
    }
}
