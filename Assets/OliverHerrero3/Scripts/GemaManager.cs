using TMPro;
using UnityEngine;

public class GemaManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gemaCountText;
    private void Update()
    {
       gemaCountText.text = $"Gemas: {Game.Instance.contadorGemas} / {Game.Instance.Gemas.Count}";
    }
} 