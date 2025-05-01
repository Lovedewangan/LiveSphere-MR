using Meta.XR.MRUtilityKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPositionForMonumentSpawn : MonoBehaviour
{
    public static FindPositionForMonumentSpawn Instance { get; private set; }

    public ObjectScaleController objectScaleController;

    [Header("Prefabs Collection")]
    public GameObject[] prefabOptions; // Array of all possible prefabs
    public string[] prefabIdentifiers;

    private int totalSpawned = 0;
    public int maxMonumentsToSpawn = 1;

    [Header("Spawn Settings")]
    public float minEdgeDistance = 0.3f;
    public MRUKAnchor.SceneLabels spawnLabels;
    public float normalOffset = 0.1f;
    public int spawnTry = 1000;
    public float maxSpawnDistance = 3.0f; // Maximum distance to spawn from camera
    public float minSpawnDistance = 0.5f; // Minimum distance to spawn from camera

    [Header("Round Settings")]
    public float roundInterval = 5f;
    public int maxRounds = 5;

    [Header("Separation Settings")]
    public float separationDistance = 0.1f;

    private List<Vector3> previousPositions = new List<Vector3>();
    private string currentIdentifier = "";

    // Track the currently spawned monument
    private GameObject currentMonument = null;

    // Reference to the main camera (usually the AR/VR headset camera)
    private Camera mainCamera;


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

    private void Start()
    {
        // Get the main camera reference
        mainCamera = Camera.main;
    }

    public void SetSpawnIdentifier(string identifier)
    {
        currentIdentifier = identifier;
    }

    // Public method to trigger spawning based on the currentIdentifier
    public void SpawnSelectedObject()
    {
        // First, remove any existing monument
        if (currentMonument != null)
        {
            Destroy(currentMonument);
            currentMonument = null;
            totalSpawned = 0; // Reset counter since we removed the monument
            previousPositions.Clear(); // Clear position tracking
        }

        if (string.IsNullOrEmpty(currentIdentifier))
            return;

        SpawnMonumentPrefab();
    }

    // You can still keep the coroutine for testing or other purposes
    public IEnumerator SpawnPrefabInRounds()
    {
        for (int round = 0; round < maxRounds; round++)
        {
            SpawnMonumentPrefab();
            yield return new WaitForSeconds(roundInterval);
        }
    }

    public void SpawnMonumentPrefab()
    {
        if (totalSpawned >= maxMonumentsToSpawn)
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

        MRUKRoom room = MRUK.Instance.GetCurrentRoom();

        // Cast ray from camera center
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        bool hasHit = room.Raycast(ray, maxSpawnDistance, LabelFilter.Included(spawnLabels), out RaycastHit hit, out MRUKAnchor anchor);

        if (hasHit)
        {
            // Calculate spawn position with normal offset
            Vector3 spawnPosition = hit.point + hit.normal * normalOffset;

            // Check if this is far enough from previous positions
            if (IsDistinctPosition(hit.point))
            {
                // Store reference to the newly spawned monument
                currentMonument = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

                objectScaleController.InitializeScalingUI(currentMonument);

                // Make the monument face the camera
                Vector3 lookDir = new Vector3(mainCamera.transform.position.x, currentMonument.transform.position.y, mainCamera.transform.position.z) -
                                  currentMonument.transform.position;
                /*currentMonument.transform.rotation = Quaternion.LookRotation(-lookDir);*/ // Face toward camera

                totalSpawned++;
                previousPositions.Add(hit.point);
                float distance = Vector3.Distance(mainCamera.transform.position, hit.point);
                Debug.Log($"Spawned monument at raycast hit point. Distance: {distance}");
            }
            else
            {
                Debug.LogWarning("Hit point too close to previously spawned position");
            }
        }
        else
        {
            Debug.LogWarning("Raycast didn't hit any valid surface");
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

    // Get specific prefab based on identifier (e.g., "USA" returns Statue of Liberty)
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

    // Add this method to your FindPositionForMonumentSpawn class
    public void DeleteCurrentMonument()
    {
        if (currentMonument != null)
        {
            Destroy(currentMonument);
            currentMonument = null;
            totalSpawned = 0; // Reset counter since we removed the monument
            previousPositions.Clear(); // Clear position tracking
        }
    }
}