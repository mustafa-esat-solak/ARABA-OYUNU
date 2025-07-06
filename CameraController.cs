using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject car; // Reference to your car
    public float fixedXPosition = 0f; // Set this to match your road's center X position

    void Update()
    {
        if (car != null)
        {
            // Get the car's world position
            Vector3 carPosition = car.transform.position;
            
            // Keep X position fixed, follow car's Y position, maintain camera's Z position
            transform.position = new Vector3(fixedXPosition, carPosition.y + 4, transform.position.z);
            
            // Keep camera rotation fixed at (0,0,0)
            transform.rotation = Quaternion.identity;
        }
    }
} 