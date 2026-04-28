using UnityEngine;
using TMPro;

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
            Debug.Log("s");
            text1.gameObject.SetActive(true);
            button1.SetActive(true);
            ChangeScene1();
        }
        if (zonaNombre == "Zona2")
        {
            text2.gameObject.SetActive(true);
            button2.SetActive(true);
            ChangeScene2();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);

    }
    void ChangeScene1()
    {
        
    }
    void ChangeScene2()
    {

    }
}
