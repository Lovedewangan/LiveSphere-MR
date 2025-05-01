using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using TMPro;

[System.Serializable]
public class FloraData
{
    public List<string> endangeredSpecies;
    public List<string> extinctSpecies;
    public List<string> commonSpecies;

    public FloraData(List<string> endangered, List<string> extinct, List<string> common)
    {
        this.endangeredSpecies = endangered;
        this.extinctSpecies = extinct;
        this.commonSpecies = common;
    }
}

[System.Serializable]
public class FaunaData
{
    public List<string> endangeredSpecies;
    public List<string> extinctSpecies;
    public List<string> commonSpecies;

    public FaunaData(List<string> endangered, List<string> extinct, List<string> common)
    {
        this.endangeredSpecies = endangered;
        this.extinctSpecies = extinct;
        this.commonSpecies = common;
    }
}

[System.Serializable]
public class RegionBiodiversityData
{
    public FloraData flora;
    public FaunaData fauna;

    public RegionBiodiversityData(FloraData flora, FaunaData fauna)
    {
        this.flora = flora;
        this.fauna = fauna;
    }
}

public class BiodiversityInfo : MonoBehaviour
{

    // Original six TextMeshProUGUI fields for each category
    public TextMeshProUGUI endangeredFloraText;
    public TextMeshProUGUI extinctFloraText;
    public TextMeshProUGUI commonFloraText;
    public TextMeshProUGUI endangeredFaunaText;
    public TextMeshProUGUI extinctFaunaText;
    public TextMeshProUGUI commonFaunaText;

    // Six additional TextMeshProUGUI fields that mirror the original ones
    public TextMeshProUGUI endangeredFloraText2;
    public TextMeshProUGUI extinctFloraText2;
    public TextMeshProUGUI commonFloraText2;
    public TextMeshProUGUI endangeredFaunaText2;
    public TextMeshProUGUI extinctFaunaText2;
    public TextMeshProUGUI commonFaunaText2;

    // Two new fields for displaying the selected state and country
    public TextMeshProUGUI selectedStateText1;
    public TextMeshProUGUI selectedStateText2;


    public Dictionary<string, RegionBiodiversityData> biodiversityDatabase = new Dictionary<string, RegionBiodiversityData>(){

    { "Andhra Pradesh", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Red Sanders", "Cycas beddomei" },
            new List<string> { "Hubbardia heptaneuron", "" },
            new List<string> { "Neem", "Bamboo" }
        ),
        new FaunaData(
            new List<string> { "Tiger", "Indian Elephant" },
            new List<string> { "Indian Pitta", "Spot-billed Pelican" },
            new List<string> { "Mugger Crocodile", "Russell's Viper" }
        )
    )},
    { "Arunachal Pradesh", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Blue Vanda Orchid", "Sapria himalayana" },
            new List<string> { "Magnolia griffithii", "Rhododendron elliotii" },
            new List<string> { "Bamboo", "Pine" }
        ),
        new FaunaData(
            new List<string> { "Red Panda", "Clouded Leopard" },
            new List<string> { "Blyth's Tragopan", "Great Hornbill" },
            new List<string> { "King Cobra", "Flying Squirrel" }
        )
    )},
    { "Assam", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Blue Vanda Orchid", "Dipterocarpus retusus" },
            new List<string> { "Madhuca insignis", "Sophora benthamii" },
            new List<string> { "Tea Plant", "Bamboo" }
        ),
        new FaunaData(
            new List<string> { "Indian Rhino", "Asian Elephant" },
            new List<string> { "Greater Adjutant Stork", "White-winged Duck" },
            new List<string> { "Gharial", "Golden Langur" }
        )
    )},
    { "Bihar", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Shorea robusta", "Acacia catechu" },
            new List<string> { "Gloriosa superba", "Rauvolfia serpentina" },
            new List<string> { "Peepal", "Neem" }
        ),
        new FaunaData(
            new List<string> { "Leopard", "Gaur" },
            new List<string> { "Sarus Crane", "Indian Peafowl" },
            new List<string> { "Mugger Crocodile", "Indian Cobra" }
        )
    )},
    { "Chhattisgarh", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Sal Tree", "Teak" },
            new List<string> { "Bauhinia tomentosa", "Malaxis muscifera" },
            new List<string> { "Bamboo", "Amla" }
        ),
        new FaunaData(
            new List<string> { "Wild Buffalo", "Indian Jackal" },
            new List<string> { "Hill Myna", "Lesser Adjutant" },
            new List<string> { "Indian Star Tortoise", "Indian Wolf" }
        )
    )},
    { "Goa", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Saraca asoca", "Mangifera indica" },
            new List<string> { "Syzygium travancoricum", "Canarium strictum" },
            new List<string> { "Coconut Palm", "Bamboo" }
        ),
        new FaunaData(
            new List<string> { "Sloth Bear", "Indian Bison" },
            new List<string> { "Malabar Trogon", "White-bellied Sea Eagle" },
            new List<string> { "Indian Rock Python", "Mugger Crocodile" }
        )
    )},
    { "Gujarat", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Asiatic Cheetah", "Banyan Tree" },
            new List<string> { "Frerea indica", "Helichrysum cutchicum" },
            new List<string> { "Neem", "Date Palm" }
        ),
        new FaunaData(
            new List<string> { "Asiatic Lion", "Blackbuck" },
            new List<string> { "Lesser Flamingo", "Sarus Crane" },
            new List<string> { "Gharial", "Star Tortoise" }
        )
    )},
    { "Haryana", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Acacia nilotica", "Prosopis cineraria" },
            new List<string> { "Taxus wallichiana", "Commiphora wightii" },
            new List<string> { "Kikar", "Neem" }
        ),
        new FaunaData(
            new List<string> { "Blackbuck", "Indian Wolf" },
            new List<string> { "Indian Peafowl", "Common Teal" },
            new List<string> { "Monitor Lizard", "Striped Hyena" }
        )
    )},
    { "Himachal Pradesh", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Taxus wallichiana", "Aconitum heterophyllum" },
            new List<string> { "Dioscorea deltoidea", "Nardostachys jatamansi" },
            new List<string> { "Deodar Cedar", "Blue Pine" }
        ),
        new FaunaData(
            new List<string> { "Snow Leopard", "Himalayan Tahr" },
            new List<string> { "Monal Pheasant", "Western Tragopan" },
            new List<string> { "Himalayan Newt", "Himalayan Pit Viper" }
        )
    )},
    { "Jharkhand", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Sal Tree", "Mahua" },
            new List<string> { "Symplocos racemosa", "Butea monosperma" },
            new List<string> { "Bamboo", "Kendu" }
        ),
        new FaunaData(
            new List<string> { "Leopard", "Sloth Bear" },
            new List<string> { "Pink-headed Duck", "Lesser Florican" },
            new List<string> { "Macaques", "Monitor Lizard" }
        )
    )},
    { "Karnataka", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Coscinium fenestratum", "Vateria indica" },
            new List<string> { "Syzygium travancoricum", "Myristica malabarica" },
            new List<string> { "Teak", "Bamboo" }
        ),
        new FaunaData(
            new List<string> { "Bengal Tiger", "Indian Elephant" },
            new List<string> { "Indian Roller", "Grey Hornbill" },
            new List<string> { "King Cobra", "Indian Pangolin" }
        )
    )},
    { "Kerala", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Syzygium travancoricum", "Vateria indica" },
            new List<string> { "Hopea jacobi", "Bentinckia condapanna" },
            new List<string> { "Coconut Palm", "Bamboo" }
        ),
        new FaunaData(
            new List<string> { "Nilgiri Tahr", "Lion-tailed Macaque" },
            new List<string> { "Malabar Trogon", "Great Hornbill" },
            new List<string> { "Olive Ridley Turtle", "King Cobra" }
        )
    )},
    { "Madhya Pradesh", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Teak", "Sal Tree" },
            new List<string> { "Butea monosperma", "Helicteres isora" },
            new List<string> { "Bamboo", "Tendu" }
        ),
        new FaunaData(
            new List<string> { "Bengal Tiger", "Barasingha" },
            new List<string> { "Sarus Crane", "Peacock" },
            new List<string> { "Indian Star Tortoise", "Russell's Viper" }
        )
    )},
    { "Maharashtra", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Teak", "Terminalia arjuna" },
            new List<string> { "Frerea indica", "Hubbardia heptaneuron" },
            new List<string> { "Bamboo", "Mango" }
        ),
        new FaunaData(
            new List<string> { "Bengal Tiger", "Leopard" },
            new List<string> { "Flamingo", "Asian Paradise Flycatcher" },
            new List<string> { "Indian Cobra", "Giant Wood Spider" }
        )
    )},
    { "Rajasthan", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Khejri Tree", "Commiphora wightii" },
            new List<string> { "Ephedra foliata", "Tecomella undulata" },
            new List<string> { "Acacia", "Cactus" }
        ),
        new FaunaData(
            new List<string> { "Indian Bustard", "Chinkara" },
            new List<string> { "Demoiselle Crane", "Indian Peafowl" },
            new List<string> { "Spiny-tailed Lizard", "Russell's Viper" }
        )
    )},
    { "Uttarakhand", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Taxus wallichiana", "Nardostachys jatamansi" },
            new List<string> { "Gentiana kurroo", "Picrorhiza kurroa" },
            new List<string> { "Deodar Cedar", "Blue Pine" }
        ),
        new FaunaData(
            new List<string> { "Snow Leopard", "Himalayan Black Bear" },
            new List<string> { "Himalayan Monal", "Western Tragopan" },
            new List<string> { "Himalayan Newt", "King Cobra" }
        )
    )},
    { "Delhi", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Mitragyna parvifolia", "Prosopis cineraria" },
            new List<string> { "Commiphora wightii", "Salvadora oleoides" },
            new List<string> { "Neem", "Peepal" }
        ),
        new FaunaData(
            new List<string> { "Nilgai", "Golden Jackal" },
            new List<string> { "Black Kite", "House Sparrow" },
            new List<string> { "Monitor Lizard", "Five-striped Palm Squirrel" }
        )
    )},
    { "Uttar Pradesh", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Dalbergia sissoo", "Shorea robusta" },
            new List<string> { "Butea monosperma", "Mallotus philippensis" },
            new List<string> { "Mango", "Neem" }
        ),
        new FaunaData(
            new List<string> { "Bengal Tiger", "Gharial" },
            new List<string> { "Sarus Crane", "Indian Peafowl" },
            new List<string> { "Indian Cobra", "Five-striped Palm Squirrel" }
        )
    )},
    { "Jammu & Kashmir", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Taxus wallichiana", "Saussurea costus" },
            new List<string> { "Juniperus polycarpos", "Nardostachys jatamansi" },
            new List<string> { "Deodar Cedar", "Chinar" }
        ),
        new FaunaData(
            new List<string> { "Kashmir Stag", "Snow Leopard" },
            new List<string> { "Black-necked Crane", "Himalayan Monal" },
            new List<string> { "Himalayan Marmot", "Himalayan Pit Viper" }
        )
    )},
    { "Punjab", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Dalbergia sissoo", "Acacia nilotica" },
            new List<string> { "Prosopis cineraria", "Salvadora oleoides" },
            new List<string> { "Kikar", "Neem" }
        ),
        new FaunaData(
            new List<string> { "Blackbuck", "Wild Boar" },
            new List<string> { "Bar-headed Goose", "Sarus Crane" },
            new List<string> { "Indian Cobra", "Monitor Lizard" }
        )
    )},
    { "Africa", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Baobab Tree", "Welwitschia mirabilis" },
            new List<string> { "St. Helena Olive", "Madagascan Banana Tree" },
            new List<string> { "Acacia", "African Lily" }
        ),
        new FaunaData(
            new List<string> { "African Elephant", "Black Rhino" },
            new List<string> { "Quagga", "Western Black Rhino" },
            new List<string> { "Wildebeest", "Zebra" }
        )
    )},
    { "USA", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "American Chestnut", "Franciscan Manzanita" },
            new List<string> { "Franklin Tree", "Passenger Pigeon Plant" },
            new List<string> { "Oak Tree", "Pine Tree" }
        ),
        new FaunaData(
            new List<string> { "Florida Panther", "California Condor" },
            new List<string> { "Passenger Pigeon", "Carolina Parakeet" },
            new List<string> { "White-tailed Deer", "American Robin" }
        )
    )},
    { "Mexico", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Mexican Oak", "Pinabete" },
            new List<string> { "Hesperocyparis guadalupensis", "Cedrela odorata" },
            new List<string> { "Cactus", "Agave" }
        ),
        new FaunaData(
            new List<string> { "Mexican Wolf", "Vaquita" },
            new List<string> { "Imperial Woodpecker", "Mexican Grizzly Bear" },
            new List<string> { "Coyote", "Jaguar" }
        )
    )},
    { "Canada", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "American Ginseng", "Cucumber Tree" },
            new List<string> { "Incised Groovebur", "Macoun's Shining Moss" },
            new List<string> { "Maple Tree", "Pine" }
        ),
        new FaunaData(
            new List<string> { "Wood Bison", "Whooping Crane" },
            new List<string> { "Dawson Caribou", "Great Auk" },
            new List<string> { "Moose", "Beaver" }
        )
    )},
    { "Colombia", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Cedrela odorata", "Podocarpus oleifolius" },
            new List<string> { "Ceroxylon quindiuense", "Juglans neotropica" },
            new List<string> { "Coffee Plant", "Orchids" }
        ),
        new FaunaData(
            new List<string> { "Andean Bear", "Pink River Dolphin" },
            new List<string> { "Colombian Grebe", "Bogota Sunangel" },
            new List<string> { "Capybara", "Toucan" }
        )
    )},
    { "Argentina", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Monkey Puzzle Tree", "Oxalis erythrorhiza" },
            new List<string> { "Yvyra Ju", "Myrocarpus frondosus" },
            new List<string> { "Ombu", "Jacaranda" }
        ),
        new FaunaData(
            new List<string> { "Jaguar", "Andean Cat" },
            new List<string> { "Glaucous Macaw", "Argentine Lake Duck" },
            new List<string> { "Guanaco", "Capybara" }
        )
    )},
    { "Brazil", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Brazil Nut Tree", "Pau Brasil" },
            new List<string> { "Cattleya labiata", "Heliconia spathocircinata" },
            new List<string> { "Açaí Palm", "Rubber Tree" }
        ),
        new FaunaData(
            new List<string> { "Golden Lion Tamarin", "Hyacinth Macaw" },
            new List<string> { "Pinta Island Tortoise", "Spix's Macaw" },
            new List<string> { "Capybara", "Toucan" }
        )
    )},
    { "Germany", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "European Yew", "Lauenburg Poppy" },
            new List<string> { "Dianthus gratianopolitanus", "Gentianella bohemica" },
            new List<string> { "Oak", "Beech" }
        ),
        new FaunaData(
            new List<string> { "European Bison", "Eurasian Lynx" },
            new List<string> { "Bavarian Giant Beetle", "Rhine Brook Lamprey" },
            new List<string> { "Red Fox", "European Rabbit" }
        )
    )},
    { "France", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Corsican Pine", "Pyrenean Violet" },
            new List<string> { "Jeanpert's Daphne", "Stapelianthus pilosus" },
            new List<string> { "Oak", "Chestnut" }
        ),
        new FaunaData(
            new List<string> { "Pyrenean Ibex", "Corsican Red Deer" },
            new List<string> { "Pyrenean Goat", "French Astronotus" },
            new List<string> { "Wild Boar", "Red Fox" }
        )
    )},
    { "Switzerland", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Edelweiss", "Lady's Slipper Orchid" },
            new List<string> { "Woodsia pulchella", "Campanula excisa" },
            new List<string> { "Spruce", "Beech" }
        ),
        new FaunaData(
            new List<string> { "Ibex", "Lynx" },
            new List<string> { "Swiss Lake Mussel", "Alpine Newt" },
            new List<string> { "Chamois", "Marmot" }
        )
    )},
    { "Russia", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Siberian Pine", "Microbiota decussata" },
            new List<string> { "Argusia sibirica", "Beckmannia eruciformis" },
            new List<string> { "Birch", "Spruce" }
        ),
        new FaunaData(
            new List<string> { "Siberian Tiger", "Polar Bear" },
            new List<string> { "Steller's Sea Cow", "Tarpan" },
            new List<string> { "Brown Bear", "Wolf" }
        )
    )},
    { "United Kingdom", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Lady's Slipper Orchid", "Shetland Mouse-ear" },
            new List<string> { "Ghost Orchid", "Dodoens' Speedwell" },
            new List<string> { "Oak", "Beech" }
        ),
        new FaunaData(
            new List<string> { "Scottish Wildcat", "Red Squirrel" },
            new List<string> { "Great Auk", "Norfolk Reed Damselfly" },
            new List<string> { "Red Fox", "Badger" }
        )
    )},
    { "Australia", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Wollemi Pine", "King's Holly" },
            new List<string> { "Sturt's Desert Pea", "Macadamia jansenii" },
            new List<string> { "Eucalyptus", "Acacia" }
        ),
        new FaunaData(
            new List<string> { "Koala", "Tasmanian Devil" },
            new List<string> { "Thylacine", "Desert Bandicoot" },
            new List<string> { "Kangaroo", "Platypus" }
        )
    )},
    { "Antarctica", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Antarctic Hair Grass", "Antarctic Pearlwort" },
            new List<string> { "No known extinct species", "" },
            new List<string> { "Lichens", "Algae" }
        ),
        new FaunaData(
            new List<string> { "Blue Whale", "Emperor Penguin" },
            new List<string> { "No documented extinct species", "" },
            new List<string> { "Adélie Penguin", "Crabeater Seal" }
        )
    )},
    { "Egypt", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Egyptian Papyrus", "Sinai Primrose" },
            new List<string> { "Egyptian Water Lily", "Desert Date Palm" },
            new List<string> { "Date Palm", "Acacia" }
        ),
        new FaunaData(
            new List<string> { "Egyptian Tortoise", "Sinai Baton Blue Butterfly" },
            new List<string> { "Egyptian Jerboa", "Barbary Lion" },
            new List<string> { "Desert Fox", "Jackal" }
        )
    )},
    { "Algeria", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Saharan Cypress", "Atlas Cedar" },
            new List<string> { "Numidian Fir", "Algerian Iris" },
            new List<string> { "Date Palm", "Alfa Grass" }
        ),
        new FaunaData(
            new List<string> { "Barbary Macaque", "Addax" },
            new List<string> { "Barbary Lion", "Atlas Bear" },
            new List<string> { "Jackal", "Desert Hedgehog" }
        )
    )},
    { "South Africa", new RegionBiodiversityData(
        new FloraData(
            new List<string> { "Bastard Quiver Tree", "Albany Cycad" },
            new List<string> { "Wood's Cycad", "Clanwilliam Cedar" },
            new List<string> { "Protea", "Aloe" }
        ),
        new FaunaData(
            new List<string> { "African Penguin", "Black Rhino" },
            new List<string> { "Quagga", "Blue Buck" },
            new List<string> { "Springbok", "Meerkat" }
        )
    )}
};

    public void FetchRegionBiodiversity(string regionName, string countryName = "India")
    {
        if (biodiversityDatabase.ContainsKey(regionName))
        {
            RegionBiodiversityData data = biodiversityDatabase[regionName];
            DisplayBiodiversityInfo(regionName, countryName, data);
        }
        else
        {
            Debug.LogError($"Region '{regionName}' not found in the biodiversity database.");
            UpdateTextFieldsWithError($"Region '{regionName}' not found.");
        }
    }

    private void DisplayBiodiversityInfo(string regionName, string countryName, RegionBiodiversityData data)
    {
        // Check if all text fields are assigned
        if (!AreTextFieldsAssigned())
        {
            Debug.LogError("One or more TextMeshProUGUI fields are not assigned.");
            return;
        }

        // Update the state and country text fields
        if (selectedStateText1 != null)
            selectedStateText1.text = $" {regionName}";
        if (selectedStateText2 != null)
            selectedStateText2.text = $" {regionName}";

        endangeredFloraText.text = $"{(data.flora.endangeredSpecies.Any() ? string.Join(", ", data.flora.endangeredSpecies) : "None")}";
        extinctFloraText.text = $"{(data.flora.extinctSpecies.Any() ? string.Join(", ", data.flora.extinctSpecies) : "None")}";
        commonFloraText.text = $"{(data.flora.commonSpecies.Any() ? string.Join(", ", data.flora.commonSpecies) : "None")}";
        endangeredFaunaText.text = $"{(data.fauna.endangeredSpecies.Any() ? string.Join(", ", data.fauna.endangeredSpecies) : "None")}";
        extinctFaunaText.text = $"{(data.fauna.extinctSpecies.Any() ? string.Join(", ", data.fauna.extinctSpecies) : "None")}";
        commonFaunaText.text = $"{(data.fauna.commonSpecies.Any() ? string.Join(", ", data.fauna.commonSpecies) : "None")}";

        // Update the mirror text fields with the same content
        if (endangeredFloraText2 != null)
            endangeredFloraText2.text = endangeredFloraText.text;
        if (extinctFloraText2 != null)
            extinctFloraText2.text = extinctFloraText.text;
        if (commonFloraText2 != null)
            commonFloraText2.text = commonFloraText.text;
        if (endangeredFaunaText2 != null)
            endangeredFaunaText2.text = endangeredFaunaText.text;
        if (extinctFaunaText2 != null)
            extinctFaunaText2.text = extinctFaunaText.text;
        if (commonFaunaText2 != null)
            commonFaunaText2.text = commonFaunaText.text;
    }

    private bool AreTextFieldsAssigned()
    {
        // Check only the original six text fields as they are required
        return endangeredFloraText != null && extinctFloraText != null && commonFloraText != null &&
               endangeredFaunaText != null && extinctFaunaText != null && commonFaunaText != null;
    }

    private void UpdateTextFieldsWithError(string errorMessage)
    {
        if (AreTextFieldsAssigned())
        {
            // Update original text fields
            endangeredFloraText.text = errorMessage;
            extinctFloraText.text = "";
            commonFloraText.text = "";
            endangeredFaunaText.text = "";
            extinctFaunaText.text = "";
            commonFaunaText.text = "";

            // Update mirror text fields
            if (endangeredFloraText2 != null)
                endangeredFloraText2.text = errorMessage;
            if (extinctFloraText2 != null)
                extinctFloraText2.text = "";
            if (commonFloraText2 != null)
                commonFloraText2.text = "";
            if (endangeredFaunaText2 != null)
                endangeredFaunaText2.text = "";
            if (extinctFaunaText2 != null)
                extinctFaunaText2.text = "";
            if (commonFaunaText2 != null)
                commonFaunaText2.text = "";

            // Clear state and country text fields
            if (selectedStateText1 != null)
                selectedStateText1.text = "";
            if (selectedStateText2 != null)
                selectedStateText2.text = "";
        }
    }
}