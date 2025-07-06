using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Yapaycan : MonoBehaviour
{
    [Header("Car Settings")]
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;
    float accelerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;

    Rigidbody2D rb;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteering();

    }

    void ApplyEngineForce()
    {
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        rb.AddForce(engineForceVector,ForceMode2D.Force);
    }
    void ApplySteering()
    {
        rotationAngle -= steeringInput * turnFactor;
        rb.MoveRotation(rotationAngle);
    }
    public void SetInputVector(Vector2 InputVector)
    {
        steeringInput = InputVector.x;
        accelerationFactor *= InputVector.y;
    }
}
