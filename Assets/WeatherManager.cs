using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class WeatherManager : MonoBehaviour
{
    public string apiUrl = "https://livesphere-backend-hp3r.onrender.com/get_weather_facts";

    // Primary fact display text fields
    public TextMeshProUGUI fact1Text, fact2Text, fact3Text;

    // Secondary fact display text fields
    public TextMeshProUGUI fact1TextSecondary, fact2TextSecondary, fact3TextSecondary;

    private const float refreshInterval = 10f; // Refresh every 10 seconds

    void Start()
    {
        // Start fetching weather facts and repeat every 10 seconds
        InvokeRepeating(nameof(RefreshWeatherFacts), 0f, refreshInterval);
    }

    public void RefreshWeatherFacts()
    {
        StartCoroutine(FetchWeatherFacts());
    }

    IEnumerator FetchWeatherFacts()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string jsonResponse = request.downloadHandler.text;
                Debug.Log("API Response: " + jsonResponse);

                // Parse JSON response
                WeatherFactsData factsData = JsonUtility.FromJson<WeatherFactsData>(jsonResponse);

                // Update both primary and secondary UI
                if (factsData.facts.Length >= 3)
                {
                    fact1Text.text = factsData.facts[0];
                    fact2Text.text = factsData.facts[1];
                    fact3Text.text = factsData.facts[2];

                    fact1TextSecondary.text = factsData.facts[0];
                    fact2TextSecondary.text = factsData.facts[1];
                    fact3TextSecondary.text = factsData.facts[2];
                }
            }
            else
            {
                Debug.LogError("Failed to fetch weather facts: " + request.error);
            }
        }
    }

    [System.Serializable]
    public class WeatherFactsData
    {
        public string[] facts;
    }
}
