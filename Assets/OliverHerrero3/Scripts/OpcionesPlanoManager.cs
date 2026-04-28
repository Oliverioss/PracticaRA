using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class OpcionesPlanoManager : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public int maxPlanos = 3;

    private List<ARPlane> planosActivos = new List<ARPlane>();

    void Update()
    {
        planosActivos.Clear();

        foreach (var plane in planeManager.trackables)
        {
            planosActivos.Add(plane);

            if (planosActivos.Count <= maxPlanos)
            {
                plane.gameObject.SetActive(true);
            }
            else
            {
                plane.gameObject.SetActive(false);
            }
        }
    }

    public void CambiarMaxPlanos(float valor)
    {
        maxPlanos = (int)valor;
    }
}