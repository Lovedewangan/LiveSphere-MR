using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class BiodiversityData
{
    public List<string> endangeredSpecies;
    public List<string> extinctSpecies;
    public List<string> commonAnimals;

    public BiodiversityData(List<string> endangeredSpecies, List<string> extinctSpecies, List<string> commonAnimals)
    {
        this.endangeredSpecies = endangeredSpecies;
        this.extinctSpecies = extinctSpecies;
        this.commonAnimals = commonAnimals;
    }
}

public class BiodiversityInfo : MonoBehaviour
{
    public TextMeshProUGUI biodiversityText;

    private Dictionary<string, BiodiversityData> biodiversityDatabase = new Dictionary<string, BiodiversityData>()
    {
          { "Andhra Pradesh", new BiodiversityData(
    new List<string> { "Tiger", "Indian Elephant", "Blackbuck" },
    new List<string> { "Indian Pitta", "Spot-billed Pelican" },
    new List<string> { "Mugger Crocodile", "Russell's Viper", "Golden Gecko" })
},
{ "Arunachal Pradesh", new BiodiversityData(
    new List<string> { "Red Panda", "Takin", "Clouded Leopard" },
    new List<string> { "Blyth's Tragopan", "Great Hornbill" },
    new List<string> { "Himalayan Newt", "King Cobra", "Flying Squirrel" })
},
{ "Assam", new BiodiversityData(
    new List<string> { "Indian Rhino", "Hoolock Gibbon", "Asian Elephant" },
    new List<string> { "Greater Adjutant Stork", "White-winged Duck" },
    new List<string> { "Bengal Monitor", "Gharial", "Golden Langur" })
},
{ "Bihar", new BiodiversityData(
    new List<string> { "Leopard", "Gaur", "Indian Pangolin" },
    new List<string> { "Sarus Crane", "Indian Peafowl" },
    new List<string> { "Gangetic Dolphin", "Mugger Crocodile", "Indian Cobra" })
},
{ "Chhattisgarh", new BiodiversityData(
    new List<string> { "Wild Buffalo", "Sloth Bear", "Indian Jackal" },
    new List<string> { "Hill Myna", "Lesser Adjutant" },
    new List<string> { "Indian Star Tortoise", "Flying Squirrel", "Indian Wolf" })
},
{ "Delhi", new BiodiversityData(
    new List<string> { "Nilgai", "Golden Jackal", "Indian Palm Civet" },
    new List<string> { "Black Kite", "House Sparrow" },
    new List<string> { "Monitor Lizard", "Five-striped Palm Squirrel", "Indian Cobra" })
},
{ "Goa", new BiodiversityData(
    new List<string> { "Malabar Civet", "Sloth Bear", "Indian Bison" },
    new List<string> { "Malabar Trogon", "White-bellied Sea Eagle" },
    new List<string> { "Olive Ridley Turtle", "Indian Rock Python", "Mugger Crocodile" })
},
{ "Gujarat", new BiodiversityData(
    new List<string> { "Asiatic Lion", "Blackbuck", "Wild Ass" },
    new List<string> { "Lesser Flamingo", "Sarus Crane" },
    new List<string> { "Gharial", "Star Tortoise", "Spiny-tailed Lizard" })
},
{ "Haryana", new BiodiversityData(
    new List<string> { "Blackbuck", "Indian Wolf", "Nilgai" },
    new List<string> { "Indian Peafowl", "Common Teal" },
    new List<string> { "Monitor Lizard", "Striped Hyena", "Indian Cobra" })
},
{ "Himachal Pradesh", new BiodiversityData(
    new List<string> { "Snow Leopard", "Himalayan Tahr", "Musk Deer" },
    new List<string> { "Monal Pheasant", "Western Tragopan" },
    new List<string> { "Himalayan Newt", "Himalayan Pit Viper", "Flying Squirrel" })
},
{ "Jammu & Kashmir", new BiodiversityData(
    new List<string> { "Kashmir Stag", "Snow Leopard", "Himalayan Black Bear" },
    new List<string> { "Black-necked Crane", "Himalayan Monal" },
    new List<string> { "Himalayan Marmot", "Himalayan Pit Viper", "Ladakh Urial" })
},
{ "Jharkhand", new BiodiversityData(
    new List<string> { "Leopard", "Sloth Bear", "Indian Wolf" },
    new List<string> { "Pink-headed Duck" },
    new List<string> { "Macaques", "Monitor Lizard", "Peacock" })
},
{ "Karnataka", new BiodiversityData(
    new List<string> { "Bengal Tiger", "Indian Elephant", "Leopard" },
    new List<string> { "Indian Roller", "Grey Hornbill" },
    new List<string> { "King Cobra", "Indian Pangolin", "Malabar Giant Squirrel" })
},
{ "Kerala", new BiodiversityData(
    new List<string> { "Nilgiri Tahr", "Lion-tailed Macaque", "Indian Pangolin" },
    new List<string> { "Malabar Trogon", "Great Hornbill" },
    new List<string> { "Olive Ridley Turtle", "King Cobra", "Malabar Pit Viper" })
},
{ "Maharashtra", new BiodiversityData(
    new List<string> { "Bengal Tiger", "Leopard", "Indian Gaur" },
    new List<string> { "Flamingo", "Asian Paradise Flycatcher" },
    new List<string> { "Indian Cobra", "Giant Wood Spider", "Indian Star Tortoise" })
},
{ "Madhya Pradesh", new BiodiversityData(
    new List<string> { "Bengal Tiger", "Barasingha", "Sloth Bear" },
    new List<string> { "Sarus Crane", "Peacock" },
    new List<string> { "Indian Star Tortoise", "Russell's Viper", "Gharial" })
},
{ "Manipur", new BiodiversityData(
    new List<string> { "Sangai Deer", "Clouded Leopard", "Hoolock Gibbon" },
    new List<string> { "Blyth's Tragopan", "Green Peafowl" },
    new List<string> { "King Cobra", "Himalayan Salamander", "Tree Frog" })
},
{ "Meghalaya", new BiodiversityData(
    new List<string> { "Clouded Leopard", "Golden Cat", "Hoolock Gibbon" },
    new List<string> { "Himalayan Griffon", "Great Hornbill" },
    new List<string> { "King Cobra", "Chinese Pangolin", "Flying Squirrel" })
},
{ "Mizoram", new BiodiversityData(
    new List<string> { "Clouded Leopard", "Hoolock Gibbon", "Serow" },
    new List<string> { "Mrs. Hume's Pheasant", "Great Hornbill" },
    new List<string> { "King Cobra", "Bamboo Pit Viper", "Giant Squirrel" })
},
{ "Nagaland", new BiodiversityData(
    new List<string> { "Clouded Leopard", "Mithun", "Hoolock Gibbon" },
    new List<string> { "Blyth's Tragopan", "Rufous-necked Hornbill" },
    new List<string> { "King Cobra", "Tokay Gecko", "Pangolin" })
},
{ "Odisha", new BiodiversityData(
    new List<string> { "Olive Ridley Turtle", "Leopard", "Gaur" },
    new List<string> { "Indian Pitta", "Lesser Adjutant" },
    new List<string> { "Mugger Crocodile", "King Cobra", "Fishing Cat" })
},
{ "Punjab", new BiodiversityData(
    new List<string> { "Blackbuck", "Wild Boar", "Indian Jackal" },
    new List<string> { "Bar-headed Goose", "Sarus Crane" },
    new List<string> { "Indian Cobra", "Monitor Lizard", "Five-striped Palm Squirrel" })
},
{ "Rajasthan", new BiodiversityData(
    new List<string> { "Indian Bustard", "Chinkara", "Desert Fox" },
    new List<string> { "Demoiselle Crane", "Indian Peafowl" },
    new List<string> { "Spiny-tailed Lizard", "Russell's Viper", "Desert Monitor" })
},
{ "Sikkim", new BiodiversityData(
    new List<string> { "Red Panda", "Snow Leopard", "Himalayan Tahr" },
    new List<string> { "Blood Pheasant", "Satyr Tragopan" },
    new List<string> { "Himalayan Newt", "Himalayan Pit Viper", "Flying Squirrel" })
},
{ "Tamil Nadu", new BiodiversityData(
    new List<string> { "Nilgiri Tahr", "Bengal Tiger", "Indian Elephant" },
    new List<string> { "Malabar Trogon", "Painted Stork" },
    new List<string> { "King Cobra", "Indian Star Tortoise", "Flying Fox" })
},
{ "Tripura", new BiodiversityData(
    new List<string> { "Clouded Leopard", "Hoolock Gibbon", "Barking Deer" },
    new List<string> { "Green Imperial Pigeon", "Lesser Adjutant" },
    new List<string> { "King Cobra", "Monitor Lizard", "Bamboo Pit Viper" })
},
{ "Telangana", new BiodiversityData(
    new List<string> { "Indian Leopard", "Sloth Bear", "Blackbuck" },
    new List<string> { "Indian Roller", "Peacock" },
    new List<string> { "Russell's Viper", "Monitor Lizard", "Indian Star Tortoise" })
},
{ "Uttar Pradesh", new BiodiversityData(
    new List<string> { "Bengal Tiger", "Gharial", "Swamp Deer" },
    new List<string> { "Sarus Crane", "Indian Peafowl" },
    new List<string> { "Indian Cobra", "Five-striped Palm Squirrel", "Mugger Crocodile" })
},
{ "Uttarakhand", new BiodiversityData(
    new List<string> { "Snow Leopard", "Himalayan Black Bear", "Musk Deer" },
    new List<string> { "Himalayan Monal", "Western Tragopan" },
    new List<string> { "Himalayan Newt", "King Cobra", "Flying Squirrel" })
},
{ "West Bengal", new BiodiversityData(
    new List<string> { "Bengal Tiger", "Indian Elephant", "Leopard" },
    new List<string> { "White-bellied Heron", "Indian Skimmer" },
    new List<string> { "King Cobra", "Mugger Crocodile", "Fishing Cat" })
},
{ "Andaman & Nicobar (UT)", new BiodiversityData(
    new List<string> { "Dugong", "Saltwater Crocodile", "Andaman Wild Boar" },
    new List<string> { "Nicobar Megapode", "Andaman Wood Pigeon" },
    new List<string> { "Olive Ridley Turtle", "Leatherback Turtle", "Monitor Lizard" })
},
{ "Chandigarh (UT)", new BiodiversityData(
    new List<string> { "Indian Palm Civet", "Golden Jackal", "Indian Hare" },
    new List<string> { "Black Kite", "Indian Peafowl" },
    new List<string> { "Monitor Lizard", "Five-striped Palm Squirrel", "Indian Cobra" })
},
{ "Dadra & Nagar Haveli (UT)", new BiodiversityData(
    new List<string> { "Leopard", "Indian Gaur", "Sloth Bear" },
    new List<string> { "Indian Peafowl", "Rufous Treepie" },
    new List<string> { "Monitor Lizard", "Russell's Viper", "Indian Cobra" })
},
{ "Daman & Diu (UT)", new BiodiversityData(
    new List<string> { "Indian Wolf", "Golden Jackal", "Striped Hyena" },
    new List<string> { "Black-winged Stilt", "Greater Flamingo" },
    new List<string> { "Olive Ridley Turtle", "Monitor Lizard", "Russell's Viper" })
},
{ "Lakshadweep (UT)", new BiodiversityData(
    new List<string> { "Spinner Dolphin", "Hawksbill Turtle", "Reef Shark" },
    new List<string> { "Brown Noddy", "Lesser Crested Tern" },
    new List<string> { "Olive Ridley Turtle", "Giant Clam", "Sea Cucumber" })
},
{ "Puducherry (UT)", new BiodiversityData(
    new List<string> { "Indian Star Tortoise", "Golden Jackal", "Indian Pangolin" },
    new List<string> { "Black-crowned Night Heron", "Indian Cormorant" },
    new List<string> { "Olive Ridley Turtle", "Indian Bullfrog", "Russell's Viper" })
}


    };

    public void FetchBiodiversityData(string stateName)
    {
        if (biodiversityDatabase.ContainsKey(stateName))
        {
            BiodiversityData data = biodiversityDatabase[stateName];
            DisplayBiodiversityInfo(stateName, data);
        }
        else
        {
            biodiversityText.text = $"No biodiversity data found for {stateName}.";
        }
    }

    void DisplayBiodiversityInfo(string stateName, BiodiversityData data)
    {
        biodiversityText.text = $" State: {stateName}\n" +
                                $"Endangered Species: {string.Join(", ", data.endangeredSpecies)}\n" +
                                $" Extinct Species: {string.Join(", ", data.extinctSpecies)}\n" +
                                $" Commonly Seen Animals: {string.Join(", ", data.commonAnimals)}";
    }
}