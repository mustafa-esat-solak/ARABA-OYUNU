using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    public GameObject fuel_0; // Benzin g�stergesi objesi

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("car")) // Arabaya �arpt���nda
        {
            if (fuel_0 != null)
            {
                fuel_0.SetActive(false);
            }

        }
    }
}