using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI; 

public class PlaneManager2 : MonoBehaviour
{
    public static PlaneManager2 Instance;
    public Slider verticalSlider;
    public Slider horizontalSlider;
    public Slider timeSlider;
    public ARPlaneManager planeManager;
    public int maxHorizontal = 0;
    public int maxVertical = 0;
    public float maxTime;
 
    [SerializeField] private Toggle oclusionToggle; 
    [SerializeField] private AROcclusionManager oclusionManager; 

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return; 
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        horizontalSlider.wholeNumbers = true;
        verticalSlider.wholeNumbers = true;
        timeSlider.wholeNumbers = true;

        horizontalSlider.onValueChanged.AddListener(OnHorizontalChanged);
        verticalSlider.onValueChanged.AddListener(OnVerticalChanged);
        timeSlider.onValueChanged.AddListener(OnTimeChanged);

        maxHorizontal = (int)horizontalSlider.value;
        maxVertical = (int)verticalSlider.value;
        maxTime = timeSlider.value;

        oclusionToggle.onValueChanged.AddListener(OnToggleChanged);
        OnToggleChanged(oclusionToggle.isOn);  
    }

    void OnVerticalChanged(float value)
    {
        maxVertical = (int)value;
    }

    void OnHorizontalChanged(float value)
    {
        maxHorizontal = (int)value;
    }

    void OnTimeChanged(float value)
    {
        maxTime = value;
    }

    void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            oclusionManager.enabled = true;
        }
        else
        {
            oclusionManager.enabled = false; 
        }
    }
}
