using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private GameObject button1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private GameObject button2;
    public string zonaNombre = "Zona1";

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {      
        if (zonaNombre == "Zona1")
        {
            text1.gameObject.SetActive(true);
            button1.SetActive(true);
        }
        
        if (zonaNombre == "Zona2")
        {
            text2.gameObject.SetActive(true);
            button2.SetActive(true);
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);

    }
    public void ChangeScene1()
    {
        LoaderUtility.Deinitialize();
        SceneManager.LoadScene("EscenaPlanos");
        SceneManager.sceneLoaded += OnSceneLoaded;
        LoaderUtility.Initialize();

    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoaderUtility.Initialize();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void ChangeScene2()
    {
        LoaderUtility.Deinitialize();
        SceneManager.LoadScene("EscenaImagen");
        SceneManager.sceneLoaded += OnSceneLoaded;
        LoaderUtility.Initialize();
    }
    public void ReturnToScene()
    {
        LoaderUtility.Deinitialize();
        SceneManager.LoadScene("EscenaMenu");
        SceneManager.sceneLoaded += OnSceneLoaded;
        LoaderUtility.Initialize();
    }
}
