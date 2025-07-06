using UnityEngine;
using UnityEngine.AI;

public class carcontroller : MonoBehaviour
{
    public float speed = 15f;
    public float rotationspeed = 200f;
    private Rigidbody2D rb;
    float moveInput, turnInput;
    public float defaultspeed = 10f;
    public float moveDirection;
    public float maxSpeed = 20f; 
    public float minSpeed = 5f;  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        
        float currentSpeed = defaultspeed;
        if (moveInput > 0) 
        {
            currentSpeed = maxSpeed;
        }
        else if (moveInput < 0) 
        {
            currentSpeed = minSpeed;
        }

        
        rb.linearVelocity = transform.up * currentSpeed;
        
        
        rb.angularVelocity = -turnInput * rotationspeed;
    }
}