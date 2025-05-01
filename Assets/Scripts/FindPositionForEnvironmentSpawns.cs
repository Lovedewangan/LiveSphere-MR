using Meta.XR.MRUtilityKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPositionForEnvironmentSpawns : MonoBehaviour
{
    [Header("Prefabs to Spawn (Randomly Chosen)")]
    public GameObject[] prefabsToSpawn; // Array of prefabs instead of single prefab

    [Header("Spawn Settings")]
    public float minEdgeDistance = 0.3f;
    public MRUKAnchor.SceneLabels spawnLabels;
    public float normalOffset = 0.1f;
    public int spawnTry = 1000;

    [Header("Round Settings")]
    public float roundInterval = 5f;
    public int maxRounds = 5;

    [Header("Separation Settings")]
    public float separationDistance = 0.1f;

    private List<Vector3> previousPositions = new List<Vector3>();
    private List<GameObject> spawnedObjects = new List<GameObject>(); // To track all spawned objects

    void Start()
    {
        StartCoroutine(SpawnPrefabInRounds());
    }

    IEnumerator SpawnPrefabInRounds()
    {
        for (int round = 0; round < maxRounds; round++)
        {
            SpawnEnvironmentPrefab();
            yield return new WaitForSeconds(roundInterval);
        }
    }

    public void SpawnEnvironmentPrefab()
    {
        if (MRUK.Instance == null || !MRUK.Instance.IsInitialized)
            return;

        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        List<Vector3> newPositions = new List<Vector3>();
        int currentTry = 0;

        while (currentTry < spawnTry)
        {
            bool hasFoundPosition = room.GenerateRandomPositionOnSurface(
                MRUK.SurfaceType.FACING_UP,
                minEdgeDistance,
                LabelFilter.Included(spawnLabels),
                out Vector3 pos,
                out Vector3 norm
            );

            if (hasFoundPosition && IsDistinctPosition(pos))
            {
                Vector3 spawnPosition = pos + norm * normalOffset;
                // Randomly choose a prefab from the array
                GameObject selectedPrefab = GetRandomPrefab();
                if (selectedPrefab != null)
                {
                    GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
                    spawnedObjects.Add(spawnedObject); // Add spawned object to the list
                    newPositions.Add(pos);
                }
                return; // Remove this line if you want to continue trying for more spawns in one call
            }
            else
            {
                currentTry++;
            }
        }
        previousPositions.AddRange(newPositions);
    }

    bool IsDistinctPosition(Vector3 newPos)
    {
        foreach (Vector3 oldPos in previousPositions)
        {
            if (Vector3.Distance(newPos, oldPos) < separationDistance)
                return false;
        }
        return true;
    }

    GameObject GetRandomPrefab()
    {
        if (prefabsToSpawn.Length == 0)
            return null;
        int randomIndex = Random.Range(0, prefabsToSpawn.Length);
        return prefabsToSpawn[randomIndex];
    }

    // New method to delete all spawned objects
    public void DeleteAllSpawnedObjects()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }

        spawnedObjects.Clear();
        previousPositions.Clear();
    }
}