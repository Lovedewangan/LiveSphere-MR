using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class WeatherTest : MonoBehaviour
{
    private string apiKey = "b9c43eebbc3aea606d57d84f846e0134"; // Replace with your OpenWeather API key

    // Main UI Text Fields
    public TextMeshProUGUI stateText;
    public TextMeshProUGUI temperatureText;
    public TextMeshProUGUI humidityText;
    public TextMeshProUGUI windSpeedText;
    public TextMeshProUGUI weatherTypeText;

    // Split UI Text Fields
    public TextMeshProUGUI stateTextSecondary;
    public TextMeshProUGUI temperatureTextSecondary;
    public TextMeshProUGUI humidityTextSecondary;
    public TextMeshProUGUI windSpeedTextSecondary;
    public TextMeshProUGUI weatherTypeTextSecondary;

    public TextMeshProUGUI hoverText; // Text element to display region name on hover

    private const string DEFAULT_HOVER_TEXT = "REGION TO BE SELECTED";
    private string currentSelectedRegion = ""; // Tracks currently selected region

    private Dictionary<string, List<string>> statesToCities = new Dictionary<string, List<string>>()
    {
        // Indian States
        { "Andhra Pradesh", new List<string> { "Visakhapatnam", "Vijayawada", "Guntur", "Tirupati" } },
        { "Arunachal Pradesh", new List<string> { "Itanagar", "Tawang", "Ziro", "Pasighat" } },
        { "Assam", new List<string> { "Guwahati", "Dibrugarh", "Silchar", "Jorhat" } },
        { "Bihar", new List<string> { "Patna", "Gaya", "Bhagalpur", "Muzaffarpur" } },
        { "Chhattisgarh", new List<string> { "Raipur", "Bilaspur", "Durg", "Korba" } },
        { "Goa", new List<string> { "Panaji", "Margao", "Vasco da Gama", "Mapusa" } },
        { "Gujarat", new List<string> { "Ahmedabad", "Surat", "Vadodara", "Rajkot" } },
        { "Haryana", new List<string> { "Chandigarh", "Faridabad", "Gurgaon", "Panipat" } },
        { "Himachal Pradesh", new List<string> { "Shimla", "Manali", "Dharamshala", "Solan" } },
        { "Jharkhand", new List<string> { "Ranchi", "Jamshedpur", "Dhanbad", "Bokaro" } },
        { "Karnataka", new List<string> { "Bangalore", "Mysore", "Mangalore", "Hubli" } },
        { "Kerala", new List<string> { "Thiruvananthapuram", "Kochi", "Kozhikode", "Thrissur" } },
        { "Madhya Pradesh", new List<string> { "Bhopal", "Indore", "Gwalior", "Jabalpur" } },
        { "Maharashtra", new List<string> { "Mumbai", "Pune", "Nagpur", "Nashik" } },
        { "Rajasthan", new List<string> { "Jaipur", "Udaipur", "Jodhpur", "Kota" } },
        { "Uttarakhand", new List<string> { "Dehradun", "Haridwar", "Nainital", "Haldwani" } },
        { "Delhi", new List<string> { "New Delhi", "Delhi Cantonment", "Rohini", "Dwarka" } },
        { "Uttar Pradesh", new List<string> { "Lucknow", "Kanpur", "Varanasi", "Agra" } },
        { "Jammu & Kashmir", new List<string> { "Srinagar", "Jammu", "Anantnag", "Baramulla" } },
        { "Punjab", new List<string> { "Chandigarh", "Amritsar", "Ludhiana", "Jalandhar" } },
        // Africa
        { "Africa", new List<string> { "Lagos", "Nairobi", "Cairo", "Cape Town" } },
        // North America
        { "USA", new List<string> { "New York", "Los Angeles", "Chicago", "Houston" } },
        { "Mexico", new List<string> { "Mexico City", "Guadalajara", "Monterrey", "Tijuana" } },
        { "Canada", new List<string> { "Toronto", "Vancouver", "Montreal", "Calgary" } },
        // South America
        { "Colombia", new List<string> { "Bogota", "Medellin", "Cali", "Barranquilla" } },
        { "Argentina", new List<string> { "Buenos Aires", "Cordoba", "Rosario", "Mendoza" } },
        { "Brazil", new List<string> { "Sao Paulo", "Rio de Janeiro", "Brasilia", "Salvador" } },
        // Europe
        { "Germany", new List<string> { "Berlin", "Munich", "Hamburg", "Frankfurt" } },
        { "France", new List<string> { "Paris", "Marseille", "Lyon", "Toulouse" } },
        { "Switzerland", new List<string> { "Zurich", "Geneva", "Bern", "Lausanne" } },
        { "Russia", new List<string> { "Moscow", "Saint Petersburg", "Novosibirsk", "Yekaterinburg" } },
        { "United Kingdom", new List<string> { "London", "Manchester", "Birmingham", "Edinburgh" } },
        // Australia
        { "Australia", new List<string> { "Sydney", "Melbourne", "Brisbane", "Perth" } },
        // Antarctica
        { "Antarctica", new List<string> { "McMurdo Station", "Amundsen-Scott Station", "Casey Station", "Davis Station" } },
        // Additional African countries
        { "Egypt", new List<string> { "Cairo", "Alexandria", "Giza", "Luxor" } },
        { "Algeria", new List<string> { "Algiers", "Oran", "Constantine", "Annaba" } },
        { "South Africa", new List<string> { "Johannesburg", "Cape Town", "Durban", "Pretoria" } },
    };

    private void Start()
    {
        // Initialize hover text with default message
        if (hoverText != null)
        {
            hoverText.text = DEFAULT_HOVER_TEXT;
        }

        // Initialize all text fields with empty values
        ClearAllTextFields();
    }

    // Clear all text fields
    private void ClearAllTextFields()
    {
        // Main UI
        if (stateText != null) stateText.text = "";
        if (temperatureText != null) temperatureText.text = "";
        if (humidityText != null) humidityText.text = "";
        if (windSpeedText != null) windSpeedText.text = "";
        if (weatherTypeText != null) weatherTypeText.text = "";

        // Secondary UI
        if (stateTextSecondary != null) stateTextSecondary.text = "";
        if (temperatureTextSecondary != null) temperatureTextSecondary.text = "";
        if (humidityTextSecondary != null) humidityTextSecondary.text = "";
        if (windSpeedTextSecondary != null) windSpeedTextSecondary.text = "";
        if (weatherTypeTextSecondary != null) weatherTypeTextSecondary.text = "";
    }

    // This is the central function that acts as an entry point for all weather fetching operations
    public void FetchStateWeather(string stateName)
    {
        // Update selected region
        currentSelectedRegion = stateName;

        if (statesToCities.ContainsKey(stateName))
        {
            // Update hover text to show selected region
            if (hoverText != null)
            {
                hoverText.text = stateName.ToUpper();
            }

            StartCoroutine(FetchWeatherForCities(stateName, statesToCities[stateName]));
        }
        else
        {
            Debug.LogError($"State '{stateName}' not found in the database.");
            string errorMsg = $"State '{stateName}' not found in the database.";

            // Display error in all text fields
            DisplayErrorMessage(errorMsg);
        }
    }

    // Display error message in all text fields
    private void DisplayErrorMessage(string errorMsg)
    {
        // Main UI
        if (stateText != null) stateText.text = errorMsg;
        if (temperatureText != null) temperatureText.text = errorMsg;
        if (humidityText != null) humidityText.text = errorMsg;
        if (windSpeedText != null) windSpeedText.text = errorMsg;
        if (weatherTypeText != null) weatherTypeText.text = errorMsg;

        // Secondary UI
        if (stateTextSecondary != null) stateTextSecondary.text = errorMsg;
        if (temperatureTextSecondary != null) temperatureTextSecondary.text = errorMsg;
        if (humidityTextSecondary != null) humidityTextSecondary.text = errorMsg;
        if (windSpeedTextSecondary != null) windSpeedTextSecondary.text = errorMsg;
        if (weatherTypeTextSecondary != null) weatherTypeTextSecondary.text = errorMsg;
    }

    // Reset the current selection
    public void ClearSelection()
    {
        currentSelectedRegion = "";
        if (hoverText != null)
        {
            hoverText.text = DEFAULT_HOVER_TEXT;
        }

        // Clear all text fields
        ClearAllTextFields();
    }

    // These methods call the central function for each state
    public void GetWeather_AndhraPradesh() => FetchStateWeather("Andhra Pradesh");
    public void GetWeather_ArunachalPradesh() => FetchStateWeather("Arunachal Pradesh");
    public void GetWeather_Assam() => FetchStateWeather("Assam");
    public void GetWeather_Bihar() => FetchStateWeather("Bihar");
    public void GetWeather_Chhattisgarh() => FetchStateWeather("Chhattisgarh");
    public void GetWeather_Goa() => FetchStateWeather("Goa");
    public void GetWeather_Gujarat() => FetchStateWeather("Gujarat");
    public void GetWeather_Haryana() => FetchStateWeather("Haryana");
    public void GetWeather_HimachalPradesh() => FetchStateWeather("Himachal Pradesh");
    public void GetWeather_Jharkhand() => FetchStateWeather("Jharkhand");
    public void GetWeather_Karnataka() => FetchStateWeather("Karnataka");
    public void GetWeather_Kerala() => FetchStateWeather("Kerala");
    public void GetWeather_MadhyaPradesh() => FetchStateWeather("Madhya Pradesh");
    public void GetWeather_Maharashtra() => FetchStateWeather("Maharashtra");
    public void GetWeather_Rajasthan() => FetchStateWeather("Rajasthan");
    public void GetWeather_Uttarakhand() => FetchStateWeather("Uttarakhand");
    public void GetWeather_Delhi() => FetchStateWeather("Delhi");
    public void GetWeather_UttarPradesh() => FetchStateWeather("Uttar Pradesh");
    public void GetWeather_JammuKashmir() => FetchStateWeather("Jammu & Kashmir");
    public void GetWeather_Punjab() => FetchStateWeather("Punjab");
    public void GetWeather_Africa() => FetchStateWeather("Africa");
    public void GetWeather_USA() => FetchStateWeather("USA");
    public void GetWeather_Mexico() => FetchStateWeather("Mexico");
    public void GetWeather_Canada() => FetchStateWeather("Canada");
    public void GetWeather_Colombia() => FetchStateWeather("Colombia");
    public void GetWeather_Argentina() => FetchStateWeather("Argentina");
    public void GetWeather_Brazil() => FetchStateWeather("Brazil");
    public void GetWeather_Germany() => FetchStateWeather("Germany");
    public void GetWeather_France() => FetchStateWeather("France");
    public void GetWeather_Switzerland() => FetchStateWeather("Switzerland");
    public void GetWeather_Russia() => FetchStateWeather("Russia");
    public void GetWeather_UnitedKingdom() => FetchStateWeather("United Kingdom");
    public void GetWeather_Australia() => FetchStateWeather("Australia");
    public void GetWeather_Antarctica() => FetchStateWeather("Antarctica");
    public void GetWeather_Egypt() => FetchStateWeather("Egypt");
    public void GetWeather_Algeria() => FetchStateWeather("Algeria");
    public void GetWeather_SouthAfrica() => FetchStateWeather("South Africa");

    // Hover functions for displaying state/country names in UPPERCASE
    public void OnHover_AndhraPradesh() => DisplayHoverInfo("Andhra Pradesh");
    public void OnHover_ArunachalPradesh() => DisplayHoverInfo("Arunachal Pradesh");
    public void OnHover_Assam() => DisplayHoverInfo("Assam");
    public void OnHover_Bihar() => DisplayHoverInfo("Bihar");
    public void OnHover_Chhattisgarh() => DisplayHoverInfo("Chhattisgarh");
    public void OnHover_Goa() => DisplayHoverInfo("Goa");
    public void OnHover_Gujarat() => DisplayHoverInfo("Gujarat");
    public void OnHover_Haryana() => DisplayHoverInfo("Haryana");
    public void OnHover_HimachalPradesh() => DisplayHoverInfo("Himachal Pradesh");
    public void OnHover_Jharkhand() => DisplayHoverInfo("Jharkhand");
    public void OnHover_Karnataka() => DisplayHoverInfo("Karnataka");
    public void OnHover_Kerala() => DisplayHoverInfo("Kerala");
    public void OnHover_MadhyaPradesh() => DisplayHoverInfo("Madhya Pradesh");
    public void OnHover_Maharashtra() => DisplayHoverInfo("Maharashtra");
    public void OnHover_Rajasthan() => DisplayHoverInfo("Rajasthan");
    public void OnHover_Uttarakhand() => DisplayHoverInfo("Uttarakhand");
    public void OnHover_Delhi() => DisplayHoverInfo("Delhi");
    public void OnHover_UttarPradesh() => DisplayHoverInfo("Uttar Pradesh");
    public void OnHover_JammuKashmir() => DisplayHoverInfo("Jammu & Kashmir");
    public void OnHover_Punjab() => DisplayHoverInfo("Punjab");
    public void OnHover_Africa() => DisplayHoverInfo("Africa");
    public void OnHover_USA() => DisplayHoverInfo("USA");
    public void OnHover_Mexico() => DisplayHoverInfo("Mexico");
    public void OnHover_Canada() => DisplayHoverInfo("Canada");
    public void OnHover_Colombia() => DisplayHoverInfo("Colombia");
    public void OnHover_Argentina() => DisplayHoverInfo("Argentina");
    public void OnHover_Brazil() => DisplayHoverInfo("Brazil");
    public void OnHover_Germany() => DisplayHoverInfo("Germany");
    public void OnHover_France() => DisplayHoverInfo("France");
    public void OnHover_Switzerland() => DisplayHoverInfo("Switzerland");
    public void OnHover_Russia() => DisplayHoverInfo("Russia");
    public void OnHover_UnitedKingdom() => DisplayHoverInfo("United Kingdom");
    public void OnHover_Australia() => DisplayHoverInfo("Australia");
    public void OnHover_Antarctica() => DisplayHoverInfo("Antarctica");
    public void OnHover_Egypt() => DisplayHoverInfo("Egypt");
    public void OnHover_Algeria() => DisplayHoverInfo("Algeria");
    public void OnHover_SouthAfrica() => DisplayHoverInfo("South Africa");

    // On exit hover, check if a region is selected before showing default text
    public void OnHoverExit()
    {
        if (hoverText != null)
        {
            // Only show default text if no region is currently selected
            if (string.IsNullOrEmpty(currentSelectedRegion))
            {
                hoverText.text = DEFAULT_HOVER_TEXT;
            }
            else
            {
                // Show the currently selected region name
                hoverText.text = currentSelectedRegion.ToUpper();
            }
        }
    }

    // Display the hovered region name in UPPERCASE
    public void DisplayHoverInfo(string regionName)
    {
        if (hoverText != null)
        {
            hoverText.text = regionName.ToUpper();
        }
    }

    IEnumerator FetchWeatherForCities(string stateName, List<string> cities)
    {
        List<float> temperatures = new List<float>();
        List<float> minTemperatures = new List<float>();
        List<float> maxTemperatures = new List<float>();
        List<int> humidities = new List<int>();
        List<float> windSpeeds = new List<float>();
        List<string> weatherConditions = new List<string>();

        foreach (string city in cities)
        {
            // Define country codes for specific regions
            Dictionary<string, string> regionCountryCodes = new Dictionary<string, string>
            {
                { "Andhra Pradesh", "IN" }, { "Arunachal Pradesh", "IN" }, { "Assam", "IN" },
                { "Bihar", "IN" }, { "Chhattisgarh", "IN" }, { "Goa", "IN" }, { "Gujarat", "IN" },
                { "Haryana", "IN" }, { "Himachal Pradesh", "IN" }, { "Jharkhand", "IN" },
                { "Karnataka", "IN" }, { "Kerala", "IN" }, { "Madhya Pradesh", "IN" },
                { "Maharashtra", "IN" }, { "Rajasthan", "IN" }, { "Uttarakhand", "IN" },
                { "Delhi", "IN" }, { "Uttar Pradesh", "IN" }, { "Jammu & Kashmir", "IN" },
                { "Punjab", "IN" },
                { "USA", "US" }, { "Mexico", "MX" }, { "Canada", "CA" },
                { "Colombia", "CO" }, { "Argentina", "AR" }, { "Brazil", "BR" },
                { "Germany", "DE" }, { "France", "FR" }, { "Switzerland", "CH" }, { "Russia", "RU" },
                { "Egypt", "EG" }, { "Algeria", "DZ" }, { "South Africa", "ZA" },
                { "United Kingdom", "GB" },
                { "Australia", "AU" }
            };

            // Use country code for specific regions, omit for Africa and Antarctica
            string url = regionCountryCodes.ContainsKey(stateName)
                ? $"https://api.openweathermap.org/data/2.5/weather?q={city},{regionCountryCodes[stateName]}&appid={apiKey}&units=metric"
                : $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Failed to fetch weather for {city}: {request.error}");
                    continue;
                }

                WeatherData weatherData = JsonUtility.FromJson<WeatherData>(request.downloadHandler.text);

                if (weatherData != null && weatherData.main != null)
                {
                    temperatures.Add(weatherData.main.temp);
                    minTemperatures.Add(weatherData.main.temp_min);
                    maxTemperatures.Add(weatherData.main.temp_max);
                    humidities.Add(weatherData.main.humidity);
                    windSpeeds.Add(weatherData.wind.speed);

                    if (weatherData.weather != null && weatherData.weather.Count > 0)
                    {
                        weatherConditions.Add(weatherData.weather[0].main);
                    }
                }
            }
        }

        if (temperatures.Count > 0)
        {
            float avgTemp = temperatures.Average();
            float minTemp = minTemperatures.Average();
            float maxTemp = maxTemperatures.Average();
            int avgHumidity = (int)humidities.Average();
            float avgWindSpeed = windSpeeds.Average();
            string mostCommonCondition = weatherConditions.GroupBy(x => x).OrderByDescending(g => g.Count()).FirstOrDefault()?.Key ?? "Unknown";

            DisplayWeatherInfo(stateName, avgTemp, minTemp, maxTemp, avgHumidity, avgWindSpeed, mostCommonCondition);
        }
        else
        {
            string noDataMsg = $"No data available for {stateName}.";
            DisplayErrorMessage(noDataMsg);
        }
    }

    void DisplayWeatherInfo(string stateName, float avgTemp, float minTemp, float maxTemp, int humidity, float windSpeed, string category)
    {
        // Format State text
        string stateInfo = $"{stateName}";

        // Format Temperature text
        string tempInfo = $"{avgTemp:F1}°C";

        // Format Humidity text
        string humidityInfo = $"{humidity}%";

        // Format Wind Speed text
        string windInfo = $"{windSpeed:F1} m/s";

        // Format Weather Type text
        string weatherInfo = $"{category}";

        // Update Main UI
        if (stateText != null) stateText.text = stateInfo;
        if (temperatureText != null) temperatureText.text = tempInfo;
        if (humidityText != null) humidityText.text = humidityInfo;
        if (windSpeedText != null) windSpeedText.text = windInfo;
        if (weatherTypeText != null) weatherTypeText.text = weatherInfo;

        // Update Secondary UI
        if (stateTextSecondary != null) stateTextSecondary.text = stateInfo;
        if (temperatureTextSecondary != null) temperatureTextSecondary.text = tempInfo;
        if (humidityTextSecondary != null) humidityTextSecondary.text = humidityInfo;
        if (windSpeedTextSecondary != null) windSpeedTextSecondary.text = windInfo;
        if (weatherTypeTextSecondary != null) weatherTypeTextSecondary.text = weatherInfo;
    }
}

[System.Serializable]
public class WeatherData
{
    public WeatherMain main;
    public List<WeatherCondition> weather;
    public WindData wind;
}

[System.Serializable]
public class WeatherMain
{
    public float temp;
    public float temp_min;
    public float temp_max;
    public int humidity;
}

[System.Serializable]
public class WindData
{
    public float speed;
}

[System.Serializable]
public class WeatherCondition
{
    public string main;
}