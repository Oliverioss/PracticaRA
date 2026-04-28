using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI; 

public class Game : MonoBehaviour
{
    public static Game Instance;
    [SerializeField] private TextMeshProUGUI horizontalText;
    [SerializeField] private TextMeshProUGUI verticalText;
    [SerializeField] private TextMeshProUGUI totalText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject startButton;
    [SerializeField] private TextMeshProUGUI winText; 
    [SerializeField] private Button backButton;

    public ARPlaneManager planeManager;

    public GameObject gemaPrefab;
    public List<GameObject> Gemas = new List<GameObject>();

    private bool gameStarted = false;
    private float currentTime;
    public int contadorGemas = 0;

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
    void Start()
    {
        startButton.SetActive(false);
        timeText.text = "";
        currentTime = PlaneManager2.Instance.maxTime;
        winText.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        backButton.onClick.AddListener(GoBackToMenu);
    }

    void Update()
    {
        int horizontales = 0;
        int verticales = 0;

        foreach (var plane in planeManager.trackables)
        {
            if (Vector3.Dot(plane.transform.up, Vector3.up) > 0.8f)
            {
                horizontales++;
            }
            else
            {
                verticales++;
            }
        }

        horizontalText.text = $"{horizontales} / {PlaneManager2.Instance.maxHorizontal}";
        verticalText.text = $"{verticales} / {PlaneManager2.Instance.maxVertical}";

        if (!gameStarted && horizontales >= PlaneManager2.Instance.maxHorizontal && verticales >= PlaneManager2.Instance.maxVertical)
        {
            startButton.SetActive(true);
        }

        if (gameStarted)
        {
            if (contadorGemas == Gemas.Count)
            {
                gameStarted = false;
                winText.gameObject.SetActive(true);
                startButton.SetActive(false);
                backButton.gameObject.SetActive(true);
            }

            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                timeText.text = currentTime.ToString("0");
            }

            horizontalText.enabled = false;
            verticalText.enabled = false;
            totalText.text = $"{contadorGemas} / {Gemas.Count}";
        }
    }

    public void StartGame()
    {
        gameStarted = true;
        currentTime = PlaneManager2.Instance.maxTime;
        startButton.SetActive(false); 
        contadorGemas = 0;
        ClearCubes();
        SpawnCubes();
        winText.gameObject.SetActive(false);
    }

    void SpawnCubes()
    {
        ClearCubes(); 

        int gemCount = PlaneManager2.Instance.maxHorizontal + PlaneManager2.Instance.maxVertical; 
        int gemasGeneradas = 0; 

        foreach (var plane in planeManager.trackables)
        {
            if (gemasGeneradas >= gemCount)
            {
                break;
            }
            Vector3 pos = plane.transform.position + Vector3.up * 0.05f; 
            SpawnCube(pos);
            gemasGeneradas++; 
        }
    }

    void SpawnCube(Vector3 pos)
    {
        GameObject gema = Instantiate(gemaPrefab, pos, Quaternion.identity);
        Gemas.Add(gema);
    }

    void ClearCubes()
    {
        foreach (var gema in Gemas)
        {
            if (gema != null)
            {
                Destroy(gema);
            }
        }
        Gemas.Clear();
    }

    public void RecogerGema()
    {
        contadorGemas++;
        AudioManager.Instance.PlayGemSound();
    }
    public void GoBackToMenu()
    {
        SceneManager.LoadScene("MenuOpciones");
    }
}