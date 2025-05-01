using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSelector : MonoBehaviour
{
    public static AnimalSelector Instance { get; private set; }
    public FindPositionForAnimalSpawn spawner;
    public static bool isAnimalModeActive = false;
    private string currentAnimalType = ""; // Track which animal is currently selected
    private bool isPendingSpawn = false; // Flag to track if we need to spawn

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

    private void Update()
    {
        // If animal mode was turned on and we have an animal selected, spawn the animal
        if (isAnimalModeActive && isPendingSpawn && !string.IsNullOrEmpty(currentAnimalType))
        {
            Debug.Log($"Auto-spawning animal: {currentAnimalType}");
            spawner.SetAnimalIdentifier(currentAnimalType);
            spawner.SpawnSelectedAnimal();
            isPendingSpawn = false; // Reset the pending flag after spawning
        }
    }

    public void ToggleAnimalMode()
    {
        isAnimalModeActive = !isAnimalModeActive;
        Debug.Log("Animal Mode Toggled: " + isAnimalModeActive);

        if (!isAnimalModeActive)
        {
            // If toggling off, delete any spawned animals
            spawner.DeleteCurrentAnimals();
            Debug.Log("Animals deleted due to toggle off");
        }
        // If we turn on animal mode and have an animal selected, mark for spawning
        else if (isAnimalModeActive && !string.IsNullOrEmpty(currentAnimalType))
        {

            isPendingSpawn = true;
            FindPositionForMonumentSpawn.Instance.DeleteCurrentMonument();
        }
    }

    // Helper method to select an animal
    private void SelectAnimal(string animalType)
    {
        currentAnimalType = animalType;
        Debug.Log($"Selected animal: {animalType}");

        if (isAnimalModeActive)
        {
            isPendingSpawn = true; // Mark for spawning in the next Update
        }
    }

    // Methods for selecting specific animal types
    public void OnMaharastraSelected()
    {
        SelectAnimal("Leopard");
    }
    public void OnUttrakhandSelected()
    {
        SelectAnimal("Musk Deer");
    }
    public void OnAntarticaSelected()
    {
        SelectAnimal("Polar Bear");
    }
}