using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

[System.Serializable]
public class MonumentsData
{
    public List<string> historicalMonuments;
    public List<string> religiousStructures;
    public List<string> modernArchitecture;
    public List<string> culturalArchitecture;

    public MonumentsData(List<string> historical, List<string> religious, List<string> modern, List<string> cultural)
    {
        this.historicalMonuments = historical;
        this.religiousStructures = religious;
        this.modernArchitecture = modern;
        this.culturalArchitecture = cultural;
    }
}

public class MonumentsManager : MonoBehaviour
{
    // Original TextMeshProUGUI fields for each category
    public TextMeshProUGUI historicalMonumentsText;
    public TextMeshProUGUI religiousStructuresText;
    public TextMeshProUGUI modernArchitectureText;
    public TextMeshProUGUI culturalArchitectureText;
    public TextMeshProUGUI selectedPlaceText;

    // Mirror TextMeshProUGUI fields that duplicate the original ones
    public TextMeshProUGUI historicalMonumentsText2;
    public TextMeshProUGUI religiousStructuresText2;
    public TextMeshProUGUI modernArchitectureText2;
    public TextMeshProUGUI culturalArchitectureText2;
    public TextMeshProUGUI selectedPlaceText2;

    public Dictionary<string, MonumentsData> monumentsDatabase = new Dictionary<string, MonumentsData>()
    {
        // Indian States
        { "Andhra Pradesh", new MonumentsData(
            new List<string> { "Golconda Fort", "Chandragiri Fort" },
            new List<string> { "Tirumala Temple", "Amaravathi Stupa" },
            new List<string> { "Cyber Towers", "Rajiv Gandhi International Airport" },
            new List<string> { "Lepakshi Temple", "Kondapalli Fort" }
        )},
        { "Arunachal Pradesh", new MonumentsData(
            new List<string> { "Ita Fort", "Bhismaknagar Fort" },
            new List<string> { "Tawang Monastery", "Gorsam Chorten" },
            new List<string> { "Sela Pass Tunnel", "Arunachal State Assembly" },
            new List<string> { "Malinithan Temple", "Namsai Golden Pagoda" }
        )},
        { "Assam", new MonumentsData(
            new List<string> { "Rang Ghar", "Talatal Ghar" },
            new List<string> { "Kamakhya Temple", "Umananda Temple" },
            new List<string> { "Saraighat Bridge", "Bogibeel Bridge" },
            new List<string> { "Kareng Ghar", "Ahom Palace" }
        )},
        { "Bihar", new MonumentsData(
            new List<string> { "Nalanda University", "Golghar" },
            new List<string> { "Mahabodhi Temple", "Vishnupad Temple" },
            new List<string> { "Gandhi Setu", "Bihar Museum" },
            new List<string> { "Kesaria Stupa", "Cyclopean Wall" }
        )},
        { "Chhattisgarh", new MonumentsData(
            new List<string> { "Kutumsar Caves", "Bastar Palace" },
            new List<string> { "Bhoramdeo Temple", "Danteshwari Temple" },
            new List<string> { "Naya Raipur", "Bastar Art Gallery" },
            new List<string> { "Laxman Temple", "Champaran" }
        )},
        { "Goa", new MonumentsData(
            new List<string> { "Aguada Fort", "Reis Magos Fort" },
            new List<string> { "Basilica of Bom Jesus", "Se Cathedral" },
            new List<string> { "Atal Setu", "Miramar Beach Promenade" },
            new List<string> { "Ancestral Goa", "Fontainhas" }
        )},
        { "Gujarat", new MonumentsData(
            new List<string> { "Laxmi Vilas Palace", "Rani ki Vav" },
            new List<string> { "Somnath Temple", "Dwarkadhish Temple" },
            new List<string> { "Statue of Unity", "Gift City" },
            new List<string> { "Adalaj Stepwell", "Patola House" }
        )},
        { "Haryana", new MonumentsData(
            new List<string> { "Kurukshetra Battlefield", "Raja Nahar Singh Palace" },
            new List<string> { "Sthaneshwar Mahadev Temple", "Jyotisar Temple" },
            new List<string> { "Cyber Hub Gurgaon", "Kingdom of Dreams" },
            new List<string> { "Sheikh Chilli's Tomb", "Pinjore Gardens" }
        )},
        { "Himachal Pradesh", new MonumentsData(
            new List<string> { "Kangra Fort", "Naggar Castle" },
            new List<string> { "Hidimba Devi Temple", "Jakhoo Temple" },
            new List<string> { "Atal Tunnel", "The Ridge Shimla" },
            new List<string> { "Tibetan Monasteries of Dharamshala", "Bhimakali Temple" }
        )},
        { "Jharkhand", new MonumentsData(
            new List<string> { "Jagannath Temple", "Canary Hill" },
            new List<string> { "Baidyanath Temple", "Maluti Temples" },
            new List<string> { "Jubilee Park", "Birsa Munda Airport" },
            new List<string> { "Tribal Research Institute", "Hundru Falls" }
        )},
        { "Karnataka", new MonumentsData(
            new List<string> { "Mysore Palace", "Hampi Ruins" },
            new List<string> { "Virupaksha Temple", "Gomateshwara Statue" },
            new List<string> { "Vidhana Soudha", "UB City" },
            new List<string> { "Hoysala Architecture", "Aihole Temples" }
        )},
        { "Kerala", new MonumentsData(
            new List<string> { "Bekal Fort", "Mattancherry Palace" },
            new List<string> { "Padmanabhaswamy Temple", "Sabarimala Temple" },
            new List<string> { "Kochi Metro", "Jatayu Earth's Center" },
            new List<string> { "Kerala Kalamandalam", "Nalukettu Houses" }
        )},
        { "Madhya Pradesh", new MonumentsData(
            new List<string> { "Gwalior Fort", "Khajuraho Temples" },
            new List<string> { "Mahakaleshwar Temple", "Sanchi Stupa" },
            new List<string> { "Raja Bhoj Airport", "DB City Mall" },
            new List<string> { "Bhimbetka Rock Shelters", "Tribal Museum" }
        )},
        { "Maharashtra", new MonumentsData(
            new List<string> { "Gateway of India", "Shaniwar Wada" },
            new List<string> { "Shirdi Sai Baba Temple", "Ellora Caves" },
            new List<string> { "Bandra-Worli Sea Link", "World One Tower" },
            new List<string> { "Wada Architecture", "Paithan Sarees Museum" }
        )},
        { "Rajasthan", new MonumentsData(
            new List<string> { "Amber Fort", "Hawa Mahal" },
            new List<string> { "Karni Mata Temple", "Dilwara Temples" },
            new List<string> { "Jaipur Metro", "World Trade Park" },
            new List<string> { "Shekhawati Havelis", "Jaisalmer Architecture" }
        )},
        { "Uttarakhand", new MonumentsData(
            new List<string> { "Adi Shankaracharya Samadhi", "Pithoragarh Fort" },
            new List<string> { "Kedarnath Temple", "Badrinath Temple" },
            new List<string> { "Tehri Dam", "Parmarth Niketan" },
            new List<string> { "Pahari Architecture", "Kumaoni Houses" }
        )},
        { "Delhi", new MonumentsData(
            new List<string> { "Red Fort", "Qutub Minar" },
            new List<string> { "Akshardham Temple", "Jama Masjid" },
            new List<string> { "Lotus Temple", "India Gate" },
            new List<string> { "Lutyens' Delhi", "Chandni Chowk" }
        )},
        { "Uttar Pradesh", new MonumentsData(
            new List<string> { "Taj Mahal", "Agra Fort" },
            new List<string> { "Kashi Vishwanath Temple", "Krishna Janmabhoomi" },
            new List<string> { "Lucknow Metro", "Yamuna Expressway" },
            new List<string> { "Lucknow Residency", "Awadhi Architecture" }
        )},
        { "Jammu & Kashmir", new MonumentsData(
            new List<string> { "Mubarak Mandi Palace", "Pari Mahal" },
            new List<string> { "Shankaracharya Temple", "Hazratbal Shrine" },
            new List<string> { "Chenab Bridge", "Srinagar Convention Centre" },
            new List<string> { "Ladakhi Architecture", "Kashmiri Wooden Houses" }
        )},
        { "Punjab", new MonumentsData(
            new List<string> { "Gobindgarh Fort", "Qila Mubarak" },
            new List<string> { "Golden Temple", "Durgiana Temple" },
            new List<string> { "Virasat-e-Khalsa", "Mohali Cricket Stadium" },
            new List<string> { "Punjabi Haveli", "Rural Architecture" }
        )},
        
        // Other Countries
        { "USA", new MonumentsData(
            new List<string> { "Statue of Liberty", "Mount Rushmore" },
            new List<string> { "Washington National Cathedral", "St. Patrick's Cathedral" },
            new List<string> { "Empire State Building", "One World Trade Center" },
            new List<string> { "Pueblo Adobe Architecture", "Antebellum Homes" }
        )},
        { "Mexico", new MonumentsData(
            new List<string> { "Chichen Itza", "Teotihuacan" },
            new List<string> { "Metropolitan Cathedral", "Basilica of Our Lady of Guadalupe" },
            new List<string> { "Torre Reforma", "Soumaya Museum" },
            new List<string> { "Mayan Architecture", "Colonial Haciendas" }
        )},
        { "Canada", new MonumentsData(
            new List<string> { "CN Tower", "Château Frontenac" },
            new List<string> { "Notre-Dame Basilica", "St. Joseph's Oratory" },
            new List<string> { "Montreal Biosphere", "Vancouver Convention Centre" },
            new List<string> { "Inuit Igloos", "Victorian Architecture" }
        )},
        { "Colombia", new MonumentsData(
            new List<string> { "Castillo San Felipe de Barajas", "Ciudad Perdida" },
            new List<string> { "Las Lajas Sanctuary", "Bogotá Cathedral" },
            new List<string> { "Torre Colpatria", "Centro de Convenciones Cartagena" },
            new List<string> { "Colonial Architecture", "Guadua Bamboo Structures" }
        )},
        { "Argentina", new MonumentsData(
            new List<string> { "Casa Rosada", "Teatro Colón" },
            new List<string> { "Metropolitan Cathedral", "Basilica of Our Lady of Luján" },
            new List<string> { "Puente de la Mujer", "Floralis Genérica" },
            new List<string> { "Pampas Estancias", "Art Deco Buenos Aires" }
        )},
        { "Brazil", new MonumentsData(
            new List<string> { "Christ the Redeemer", "Amazon Theatre" },
            new List<string> { "São Paulo Cathedral", "Sanctuary of Bom Jesus do Congonhas" },
            new List<string> { "Museum of Tomorrow", "Oscar Niemeyer Museum" },
            new List<string> { "Pampulha Architectural Complex", "Indigenous Maloca" }
        )},
        { "Germany", new MonumentsData(
            new List<string> { "Brandenburg Gate", "Neuschwanstein Castle" },
            new List<string> { "Cologne Cathedral", "Aachen Cathedral" },
            new List<string> { "Berlin TV Tower", "Olympic Stadium" },
            new List<string> { "Bavarian Architecture", "Half-timbered Houses" }
        )},
        { "France", new MonumentsData(
            new List<string> { "Eiffel Tower", "Arc de Triomphe" },
            new List<string> { "Notre-Dame Cathedral", "Sacré-Cœur" },
            new List<string> { "Centre Pompidou", "Louvre Pyramid" },
            new List<string> { "Provence Stone Houses", "Normandy Architecture" }
        )},
        { "Switzerland", new MonumentsData(
            new List<string> { "Château de Chillon", "Federal Palace of Switzerland" },
            new List<string> { "Grossmünster", "Abbey of Saint Gall" },
            new List<string> { "Jet d'Eau", "Prime Tower" },
            new List<string> { "Swiss Chalets", "Alpine Architecture" }
        )},
        { "Russia", new MonumentsData(
            new List<string> { "Kremlin", "Winter Palace" },
            new List<string> { "Saint Basil's Cathedral", "Cathedral of Christ the Saviour" },
            new List<string> { "Moscow International Business Center", "Lakhta Center" },
            new List<string> { "Wooden Churches of Kizhi", "Siberian Log Houses" }
        )},
        { "United Kingdom", new MonumentsData(
            new List<string> { "Tower of London", "Big Ben" },
            new List<string> { "Westminster Abbey", "St. Paul's Cathedral" },
            new List<string> { "The Shard", "London Eye" },
            new List<string> { "Cotswold Architecture", "Scottish Castles" }
        )},
        { "Australia", new MonumentsData(
            new List<string> { "Sydney Opera House", "Port Arthur Historic Site" },
            new List<string> { "St. Mary's Cathedral", "St. Patrick's Cathedral" },
            new List<string> { "Q1", "Federation Square" },
            new List<string> { "Queenslander Houses", "Aboriginal Shelters" }
        )},
        { "Egypt", new MonumentsData(
            new List<string> { "Great Pyramids of Giza", "Temple of Karnak" },
            new List<string> { "Al-Azhar Mosque", "Abu Simbel Temples" },
            new List<string> { "Cairo Tower", "The Grand Egyptian Museum" },
            new List<string> { "Nubian Houses", "Islamic Cairo" }
        )},
        { "Algeria", new MonumentsData(
            new List<string> { "Djémila", "Timgad Roman Ruins" },
            new List<string> { "Ketchaoua Mosque", "Notre Dame d'Afrique" },
            new List<string> { "Monument of the Martyrs", "Great Mosque of Algiers" },
            new List<string> { "Casbah of Algiers", "M'zab Valley Architecture" }
        )},
        { "South Africa", new MonumentsData(
            new List<string> { "Robben Island", "Castle of Good Hope" },
            new List<string> { "St. George's Cathedral", "Groot Constantia" },
            new List<string> { "Ponte City Apartments", "Constitutional Court" },
            new List<string> { "Cape Dutch Architecture", "Ndebele House Painting" }
        )}
    };

    public void FetchRegionMonuments(string placeName)
    {
        if (monumentsDatabase.ContainsKey(placeName))
        {
            MonumentsData data = monumentsDatabase[placeName];
            DisplayMonumentsInfo(placeName, data);
        }
        else
        {
            Debug.LogError($"Place '{placeName}' not found in the monuments database.");
            UpdateTextFieldsWithError($"Place '{placeName}' not found.");
        }
    }

    private void DisplayMonumentsInfo(string placeName, MonumentsData data)
    {
        // Check if all text fields are assigned
        if (!AreTextFieldsAssigned())
        {
            Debug.LogError("One or more TextMeshProUGUI fields are not assigned.");
            return;
        }

        // Update the place name text fields
        if (selectedPlaceText != null)
            selectedPlaceText.text = $"{placeName}";

        // Update each original text field with the corresponding monuments list
        historicalMonumentsText.text = $"{(data.historicalMonuments.Any() ? string.Join(", ", data.historicalMonuments) : "None")}";
        religiousStructuresText.text = $"{(data.religiousStructures.Any() ? string.Join(", ", data.religiousStructures) : "None")}";
        modernArchitectureText.text = $"{(data.modernArchitecture.Any() ? string.Join(", ", data.modernArchitecture) : "None")}";
        culturalArchitectureText.text = $"{(data.culturalArchitecture.Any() ? string.Join(", ", data.culturalArchitecture) : "None")}";

        // Update the mirror text fields with the same content
        if (selectedPlaceText2 != null)
            selectedPlaceText2.text = selectedPlaceText.text;
        if (historicalMonumentsText2 != null)
            historicalMonumentsText2.text = historicalMonumentsText.text;
        if (religiousStructuresText2 != null)
            religiousStructuresText2.text = religiousStructuresText.text;
        if (modernArchitectureText2 != null)
            modernArchitectureText2.text = modernArchitectureText.text;
        if (culturalArchitectureText2 != null)
            culturalArchitectureText2.text = culturalArchitectureText.text;
    }

    private bool AreTextFieldsAssigned()
    {
        // Check only the original five text fields as they are required
        return historicalMonumentsText != null && religiousStructuresText != null && 
               modernArchitectureText != null && culturalArchitectureText != null && 
               selectedPlaceText != null;
    }

    private void UpdateTextFieldsWithError(string errorMessage)
    {
        if (AreTextFieldsAssigned())
        {
            // Update original text fields
            historicalMonumentsText.text = errorMessage;
            religiousStructuresText.text = "";
            modernArchitectureText.text = "";
            culturalArchitectureText.text = "";
            selectedPlaceText.text = "";

            // Update mirror text fields
            if (historicalMonumentsText2 != null)
                historicalMonumentsText2.text = errorMessage;
            if (religiousStructuresText2 != null)
                religiousStructuresText2.text = "";
            if (modernArchitectureText2 != null)
                modernArchitectureText2.text = "";
            if (culturalArchitectureText2 != null)
                culturalArchitectureText2.text = "";
            if (selectedPlaceText2 != null)
                selectedPlaceText2.text = "";
        }
    }
}