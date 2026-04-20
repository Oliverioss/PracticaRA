using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;
using TMPro;
public class PlaneManager : MonoBehaviour
{
    public int contadorPlanos;
    [SerializeField] private TextMeshProUGUI planeText;
    public ARPlaneManager planeManager;

    void Update()
    {
        // Cuenta los planos activos actualmente
        int totalPlanos = planeManager.trackables.count;
        planeText.text = totalPlanos.ToString();
    }
}
