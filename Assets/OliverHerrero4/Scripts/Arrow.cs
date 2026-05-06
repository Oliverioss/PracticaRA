using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
public class Arrow : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            ArrowManager.Instance.arrowList[0 + ArrowManager.Instance.j].SetActive(false);
            ArrowManager.Instance.arrowList[1 + ArrowManager.Instance.j].SetActive(true);
            ArrowManager.Instance.j++;
        }
    }
}
