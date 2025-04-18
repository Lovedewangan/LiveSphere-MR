using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Globe;
    public void TurnOnSpawning()
    {
        StartCoroutine(SpawningRoutine());

    }

    IEnumerator SpawningRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        Globe.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        Globe.SetActive(false);
        TurnOnSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
