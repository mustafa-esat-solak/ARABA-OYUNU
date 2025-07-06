using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    public GameObject fuel_0; // Benzin göstergesi objesi

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("car")) // Arabaya çarptýðýnda
        {
            if (fuel_0 != null)
            {
                fuel_0.SetActive(false);
            }

        }
    }
}