using Meta.XR.MRUtilityKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPositionForAnimalSpawn : MonoBehaviour
{
    public static FindPositionForAnimalSpawn Instance { get; private set; }
    [Header("Prefabs Collection")]
    public GameObject[] prefabOptions; // Array of all possible animal prefabs
    public string[] prefabIdentifiers; // Names/identifiers for each animal prefab

    private int totalSpawned = 0;
    public int maxAnimalsToSpawn = 2;

    [Header("Spawn Settings")]
    public float minEdgeDistance = 0.3f;
    public MRUKAnchor.SceneLabels spawnLabels;
    public float normalOffset = 0.1f;
    public int spawnTry = 1000;

    [Header("Player Distance Settings")]
    public float minPlayerDistance = 1.0f; // Minimum distance from player
    public float maxSpawnDistance = 5.0f; // Maximum distance to spawn from player

    [Header("Round Settings")]
    public float roundInterval = 5f;
    public int maxRounds = 5;

    [Header("Separation Settings")]
    public float separationDistance = 0.1f;

    private List<Vector3> previousPositions = new List<Vector3>();
    private Camera mainCamera; // Reference to the main camera (player's view)

    // Track currently spawned animals
    private List<GameObject> currentAnimals = new List<GameObject>();
    private string currentIdentifier = "";

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);  // Destroy duplicate instances
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);  // Optional: keeps the instance across scenes
    }

    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found!");
        }
    }

    // Set the identifier for the animal to spawn
    public void SetAnimalIdentifier(string identifier)
    {
        currentIdentifier = identifier;
    }

    // Public method to trigger spawning based on the currentIdentifier
    public void SpawnSelectedAnimal()
    {
        if (currentAnimals != null)
        {
            foreach (GameObject animal in currentAnimals)
            {
                if (animal != null)
                {
                    Destroy(animal);
                }
            }

            currentAnimals.Clear();
            totalSpawned = 0; // Reset counter since we removed all animals
            previousPositions.Clear(); // Clear position tracking
        }


        if (string.IsNullOrEmpty(currentIdentifier))
            return;

        SpawnAnimalPrefab();
    }

    // Still keep the coroutine for testing or other purposes
    public IEnumerator SpawnPrefabInRounds()
    {
        for (int round = 0; round < maxRounds; round++)
        {
            SpawnAnimalPrefab();
            yield return new WaitForSeconds(roundInterval);
        }
    }

    public void SpawnAnimalPrefab()
    {
        if (totalSpawned >= maxAnimalsToSpawn)
            return;

        if (MRUK.Instance == null || !MRUK.Instance.IsInitialized)
            return;

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            if (mainCamera == null)
            {
                Debug.LogError("Main camera not found!");
                return;
            }
        }

        // Get the specific prefab based on identifier
        GameObject prefabToSpawn = GetPrefabByIdentifier(currentIdentifier);
        if (prefabToSpawn == null)
            return;

        Vector3 playerPosition = mainCamera.transform.position;
        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
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

            float distanceFromPlayer = Vector3.Distance(playerPosition, pos);

            if (hasFoundPosition &&
                IsDistinctPosition(pos) &&
                distanceFromPlayer >= minPlayerDistance &&
                distanceFromPlayer <= maxSpawnDistance)
            {
                Vector3 spawnPosition = pos + norm * normalOffset;

                // Spawn the selected animal prefab
                GameObject spawnedAnimal = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

                // Make the animal face a random direction
                Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
                spawnedAnimal.transform.rotation = Quaternion.LookRotation(randomDirection);

                totalSpawned++;
                previousPositions.Add(pos);
                currentAnimals.Add(spawnedAnimal);

                Debug.Log($"Spawned {currentIdentifier} at distance: {distanceFromPlayer} from player");
                break; // Found a valid position, exit the loop
            }

            currentTry++;
        }

        if (currentTry >= spawnTry)
        {
            Debug.LogWarning("Couldn't find suitable position after " + spawnTry + " attempts");
        }
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

    // Get specific prefab based on identifier (e.g., "Lion" returns Lion prefab)
    GameObject GetPrefabByIdentifier(string identifier)
    {
        if (prefabOptions.Length == 0 || prefabIdentifiers.Length == 0)
            return null;

        // Find the index of the identifier in the array
        for (int i = 0; i < prefabIdentifiers.Length; i++)
        {
            if (prefabIdentifiers[i] == identifier && i < prefabOptions.Length)
            {
                return prefabOptions[i];
            }
        }

        // If not found, return null or a default prefab
        Debug.LogWarning("No prefab found for identifier: " + identifier);
        return null;
    }

    // Method to delete all spawned animals
    public void DeleteCurrentAnimals()
    {
        foreach (GameObject animal in currentAnimals)
        {
            if (animal != null)
            {
                Destroy(animal);
            }
        }

        currentAnimals.Clear();
        totalSpawned = 0; // Reset counter since we removed all animals
        previousPositions.Clear(); // Clear position tracking
    }
}