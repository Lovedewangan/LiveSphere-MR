using UnityEngine;

public class RegionSelector : MonoBehaviour
{
    public BiodiversityInfo biodiversityManager;

    void Start()
    {
        biodiversityManager = FindObjectOfType<BiodiversityInfo>();

        if (biodiversityManager == null)
        {
            Debug.LogError("BiodiversityManager not found in scene!");
        }
    }

    // Indian States
    public void SelectAndhraPradesh() { biodiversityManager.FetchRegionBiodiversity("Andhra Pradesh"); }
    public void SelectArunachalPradesh() { biodiversityManager.FetchRegionBiodiversity("Arunachal Pradesh"); }
    public void SelectAssam() { biodiversityManager.FetchRegionBiodiversity("Assam"); }
    public void SelectBihar() { biodiversityManager.FetchRegionBiodiversity("Bihar"); }
    public void SelectChhattisgarh() { biodiversityManager.FetchRegionBiodiversity("Chhattisgarh"); }
    public void SelectGoa() { biodiversityManager.FetchRegionBiodiversity("Goa"); }
    public void SelectGujarat() { biodiversityManager.FetchRegionBiodiversity("Gujarat"); }
    public void SelectHaryana() { biodiversityManager.FetchRegionBiodiversity("Haryana"); }
    public void SelectHimachalPradesh() { biodiversityManager.FetchRegionBiodiversity("Himachal Pradesh"); }
    public void SelectJharkhand() { biodiversityManager.FetchRegionBiodiversity("Jharkhand"); }
    public void SelectKarnataka() { biodiversityManager.FetchRegionBiodiversity("Karnataka"); }
    public void SelectKerala() { biodiversityManager.FetchRegionBiodiversity("Kerala"); }
    public void SelectMadhyaPradesh() { biodiversityManager.FetchRegionBiodiversity("Madhya Pradesh"); }
    public void SelectMaharashtra() { biodiversityManager.FetchRegionBiodiversity("Maharashtra"); }
    public void SelectRajasthan() { biodiversityManager.FetchRegionBiodiversity("Rajasthan"); }
    public void SelectUttarakhand() { biodiversityManager.FetchRegionBiodiversity("Uttarakhand"); }
    public void SelectDelhi() { biodiversityManager.FetchRegionBiodiversity("Delhi"); }
    public void SelectUttarPradesh() { biodiversityManager.FetchRegionBiodiversity("Uttar Pradesh"); }
    public void SelectJammuAndKashmir() { biodiversityManager.FetchRegionBiodiversity("Jammu & Kashmir"); }
    public void SelectPunjab() { biodiversityManager.FetchRegionBiodiversity("Punjab"); }

    // Countries and Continents
    public void SelectAfrica() { biodiversityManager.FetchRegionBiodiversity("Africa"); }
    public void SelectUSA() { biodiversityManager.FetchRegionBiodiversity("USA"); }
    public void SelectMexico() { biodiversityManager.FetchRegionBiodiversity("Mexico"); }
    public void SelectCanada() { biodiversityManager.FetchRegionBiodiversity("Canada"); }
    public void SelectColombia() { biodiversityManager.FetchRegionBiodiversity("Colombia"); }
    public void SelectArgentina() { biodiversityManager.FetchRegionBiodiversity("Argentina"); }
    public void SelectBrazil() { biodiversityManager.FetchRegionBiodiversity("Brazil"); }
    public void SelectGermany() { biodiversityManager.FetchRegionBiodiversity("Germany"); }
    public void SelectFrance() { biodiversityManager.FetchRegionBiodiversity("France"); }
    public void SelectSwitzerland() { biodiversityManager.FetchRegionBiodiversity("Switzerland"); }
    public void SelectRussia() { biodiversityManager.FetchRegionBiodiversity("Russia"); }
    public void SelectUnitedKingdom() { biodiversityManager.FetchRegionBiodiversity("United Kingdom"); }
    public void SelectAustralia() { biodiversityManager.FetchRegionBiodiversity("Australia"); }
    public void SelectAntarctica() { biodiversityManager.FetchRegionBiodiversity("Antarctica"); }
    public void SelectEgypt() { biodiversityManager.FetchRegionBiodiversity("Egypt"); }
    public void SelectAlgeria() { biodiversityManager.FetchRegionBiodiversity("Algeria"); }
    public void SelectSouthAfrica() { biodiversityManager.FetchRegionBiodiversity("South Africa"); }
}