using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class OpcionesManager : MonoBehaviour
{
    public Slider sliderHorizontal;
    public TextMeshProUGUI textHorizontal;
    public int horizontalValue;

    public Slider sliderVertical;
    public TextMeshProUGUI textVertical;
    public int verticalValue;

    public Slider sliderTime;
    public TextMeshProUGUI textTime;
    public int timeValue;

    public Toggle toggle;
    public bool isActive;
    void Start()
    {
        sliderHorizontal.wholeNumbers = true;
        sliderHorizontal.minValue = 0;
        sliderHorizontal.maxValue = 10;

        sliderHorizontal.onValueChanged.AddListener(HorizontalChange);
        HorizontalChange(sliderHorizontal.value);

        sliderVertical.wholeNumbers = true;
        sliderVertical.minValue = 0;
        sliderVertical.maxValue = 10;

        sliderVertical.onValueChanged.AddListener(VerticalChange);
        VerticalChange(sliderVertical.value);

        sliderTime.wholeNumbers = true;
        sliderTime.minValue = 0;
        sliderTime.maxValue = 60;

        sliderTime.onValueChanged.AddListener(TimeChange);
        TimeChange(sliderTime.value);

        toggle.onValueChanged.AddListener(ChangeOclusion);
        ChangeOclusion(toggle.isOn);
    }
    void HorizontalChange(float value)
    {
        horizontalValue = (int)value;

        if (textHorizontal != null)
        {
            textHorizontal.text = horizontalValue.ToString();
        }
    }
    void VerticalChange(float value)
    {
        verticalValue = (int)value;

        if (textVertical != null)
        {
            textVertical.text = verticalValue.ToString();
        }
    }
    void TimeChange(float value)
    {
        timeValue = (int)value;

        if (textTime != null)
        {
            textTime.text = timeValue.ToString();
        }
    }
    void ChangeOclusion(bool valor)
    {
        isActive = valor;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoaderUtility.Initialize();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void ChangeToKitchen()
    {
        LoaderUtility.Deinitialize();
        SceneManager.LoadScene("Kitchen");
        SceneManager.sceneLoaded += OnSceneLoaded;
        LoaderUtility.Initialize();

    }
}
