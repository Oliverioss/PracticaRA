using UnityEngine;

public class Gema : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Game.Instance.RecogerGema();
        Destroy(gameObject);
    }
}