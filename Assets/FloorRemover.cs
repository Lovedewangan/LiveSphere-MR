using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRemover : MonoBehaviour
{
    public void SandRemove()
    {
        GameObject sand = GameObject.FindGameObjectWithTag("Sand Floor");
        if(sand != null)
        {
            Destroy(sand);
        }
    }

    public void SnowRemove()
    {
        GameObject snow = GameObject.FindGameObjectWithTag("Snow Floor");
        if (snow != null)
        {
            Destroy(snow);
        }
    }
}
