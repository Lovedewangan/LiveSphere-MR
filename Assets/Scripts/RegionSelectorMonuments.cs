using UnityEngine;

public class RegionSelectorMonuments : MonoBehaviour
{
    public MonumentsManager monumentsManager;

    void Start()
    {
        monumentsManager = FindObjectOfType<MonumentsManager>();
        if (monumentsManager == null)
        {
            Debug.LogError("MonumentsManager not found in scene!");
        }
    }

    // Indian States
    public void SelectAndhraPradesh() { monumentsManager.FetchRegionMonuments("Andhra Pradesh"); }
    public void SelectArunachalPradesh() { monumentsManager.FetchRegionMonuments("Arunachal Pradesh"); }
    public void SelectAssam() { monumentsManager.FetchRegionMonuments("Assam"); }
    public void SelectBihar() { monumentsManager.FetchRegionMonuments("Bihar"); }
    public void SelectChhattisgarh() { monumentsManager.FetchRegionMonuments("Chhattisgarh"); }
    public void SelectGoa() { monumentsManager.FetchRegionMonuments("Goa"); }
    public void SelectGujarat() { monumentsManager.FetchRegionMonuments("Gujarat"); }
    public void SelectHaryana() { monumentsManager.FetchRegionMonuments("Haryana"); }
    public void SelectHimachalPradesh() { monumentsManager.FetchRegionMonuments("Himachal Pradesh"); }
    public void SelectJharkhand() { monumentsManager.FetchRegionMonuments("Jharkhand"); }
    public void SelectKarnataka() { monumentsManager.FetchRegionMonuments("Karnataka"); }
    public void SelectKerala() { monumentsManager.FetchRegionMonuments("Kerala"); }
    public void SelectMadhyaPradesh() { monumentsManager.FetchRegionMonuments("Madhya Pradesh"); }
    public void SelectMaharashtra() { monumentsManager.FetchRegionMonuments("Maharashtra"); }
    public void SelectRajasthan() { monumentsManager.FetchRegionMonuments("Rajasthan"); }
    public void SelectUttarakhand() { monumentsManager.FetchRegionMonuments("Uttarakhand"); }
    public void SelectDelhi() { monumentsManager.FetchRegionMonuments("Delhi"); }
    public void SelectUttarPradesh() { monumentsManager.FetchRegionMonuments("Uttar Pradesh"); }
    public void SelectJammuAndKashmir() { monumentsManager.FetchRegionMonuments("Jammu & Kashmir"); }
    public void SelectPunjab() { monumentsManager.FetchRegionMonuments("Punjab"); }

    // Other Countries
    public void SelectUSA() { monumentsManager.FetchRegionMonuments("USA"); }
    public void SelectMexico() { monumentsManager.FetchRegionMonuments("Mexico"); }
    public void SelectCanada() { monumentsManager.FetchRegionMonuments("Canada"); }
    public void SelectColombia() { monumentsManager.FetchRegionMonuments("Colombia"); }
    public void SelectArgentina() { monumentsManager.FetchRegionMonuments("Argentina"); }
    public void SelectBrazil() { monumentsManager.FetchRegionMonuments("Brazil"); }
    public void SelectGermany() { monumentsManager.FetchRegionMonuments("Germany"); }
    public void SelectFrance() { monumentsManager.FetchRegionMonuments("France"); }
    public void SelectSwitzerland() { monumentsManager.FetchRegionMonuments("Switzerland"); }
    public void SelectRussia() { monumentsManager.FetchRegionMonuments("Russia"); }
    public void SelectUnitedKingdom() { monumentsManager.FetchRegionMonuments("United Kingdom"); }
    public void SelectAustralia() { monumentsManager.FetchRegionMonuments("Australia"); }
    public void SelectEgypt() { monumentsManager.FetchRegionMonuments("Egypt"); }
    public void SelectAlgeria() { monumentsManager.FetchRegionMonuments("Algeria"); }
    public void SelectSouthAfrica() { monumentsManager.FetchRegionMonuments("South Africa"); }
}