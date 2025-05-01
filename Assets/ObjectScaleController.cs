using UnityEngine;
using UnityEngine.UI;

public class ObjectScaleController : MonoBehaviour
{
    public GameObject canvas;            // The UI Canvas
    public Slider scaleSlider;           // The Slider UI
    public Button doneButton;            // The Done Button
    public Transform xrRig;              // Reference to XR Rig (Camera Origin)

    private GameObject targetObject;     // The object to scale

    [Range(0.1f, 10f)]
    public float minScale = 0.5f;
    [Range(0.1f, 10f)]
    public float maxScale = 3.0f;


    void Start()
    {
        canvas.SetActive(false);
        doneButton.onClick.AddListener(OnDoneButtonClicked);
    }

    public void InitializeScalingUI(GameObject instantiatedObject)
    {
        targetObject = instantiatedObject;

        // Set slider limits
        scaleSlider.minValue = minScale;
        scaleSlider.maxValue = maxScale;

        // Set current scale
        float currentScale = targetObject.transform.localScale.x;
        scaleSlider.value = Mathf.Clamp(currentScale, minScale, maxScale);

        // Add listener
        scaleSlider.onValueChanged.RemoveAllListeners();
        scaleSlider.onValueChanged.AddListener(OnSliderValueChanged);

        canvas.SetActive(true);
    }



    private void OnSliderValueChanged(float newValue)
    {
        if (targetObject != null)
        {
            float clampedValue = Mathf.Clamp(newValue, minScale, maxScale);
            targetObject.transform.localScale = new Vector3(clampedValue, clampedValue, clampedValue);
        }
    }


    private void OnDoneButtonClicked()
    {
        canvas.SetActive(false);
    }
}