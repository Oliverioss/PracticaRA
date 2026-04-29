using System.Collections.Generic;
using UnityEngine;
public class ArrowManager : MonoBehaviour
{
    public GameObject[] arrowList;
    public static ArrowManager Instance;
    public int j = 0;

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
       for (int i = 0; i < arrowList.Length; i++)
       {
            arrowList[i].SetActive(false);
       }
    }
   public void ActivarPrimeraFlecha()
   {
        arrowList[0].SetActive(true);
   }
}
