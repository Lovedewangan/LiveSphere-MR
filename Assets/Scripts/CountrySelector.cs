using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountrySelector : MonoBehaviour
{
    public static CountrySelector Instance { get; private set; }
    public FindPositionForMonumentSpawn spawner;
    public static bool isMonumentTrue = false;
    private string currentCountry = ""; // Track which country is currently selected
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
        // If monument mode was turned on and we have a country selected, spawn the monument
        if (isMonumentTrue && isPendingSpawn && !string.IsNullOrEmpty(currentCountry))
        {
            Debug.Log($"Auto-spawning monument for {currentCountry}");
            spawner.SetSpawnIdentifier(currentCountry);
            spawner.SpawnSelectedObject();
            isPendingSpawn = false; // Reset the pending flag after spawning
        }
    }

    public void ToggleMonument()
    {
        isMonumentTrue = !isMonumentTrue;
        Debug.Log("Monument Toggled: " + isMonumentTrue);

        if (!isMonumentTrue)
        {
            // If toggling off, delete any spawned monument
            spawner.DeleteCurrentMonument();
            Debug.Log("Monument deleted due to toggle off");
        }
        // If we turn on monuments and have a country selected, mark for spawning
        else if (isMonumentTrue && !string.IsNullOrEmpty(currentCountry))
        {
            isPendingSpawn = true;
            FindPositionForAnimalSpawn.Instance.DeleteCurrentAnimals();
        }
    }

    // Helper method to select a country
    private void SelectCountry(string country)
    {
        currentCountry = country;
        Debug.Log($"Selected country: {country}");

        if (isMonumentTrue)
        {
            isPendingSpawn = true; // Mark for spawning in the next Update
        }
    }

    public void OnKarnatakaSelected()
    {
        SelectCountry("Karnataka");
    }
    public void OnGujaratSelected()
    {
        SelectCountry("Gujarat");
    }
    public void OnUSASelected()
    {
        SelectCountry("USA");
    }

    public void OnFranceSelected()
    {
        SelectCountry("France");
    }

    public void OnMexicoSelected()
    {
        SelectCountry("Mexico");
    }

    public void OnUKSelected()
    {
        SelectCountry("UK");
    }

    public void OnSouthAfricaSelected()
    {
        SelectCountry("SouthAfrica");
    }

    public void OnEgyptSelected()
    {
        SelectCountry("Egypt");
    }

    public void OnGermanySelected()
    {
        SelectCountry("Germany");
    }

    public void OnCanadaSelected()
    {
        SelectCountry("Canada");
    }

    public void OnBrazilSelected()
    {
        SelectCountry("Brazil");
    }

    public void OnArgentinaSelected()
    {
        SelectCountry("Argentina");
    }
}