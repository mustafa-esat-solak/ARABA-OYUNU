using UnityEngine;

public class BotCarController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxSpeed = 20f;
    public float minSpeed = 5f;
    public float acceleration = 2f;
    public float deceleration = 4f;
    public float slideSpeed = 5f; // Speed of lateral movement
    public float maxSlideAngle = 30f; // Maximum angle the car can tilt while sliding

    [Header("Detection Settings")]
    public float detectionDistance = 5f;
    public float sideDetectionDistance = 3f;
    public LayerMask npcLayer;
    public float safeDistance = 2f;

    private Rigidbody2D rb;
    private float currentSpeed;
    private float targetSpeed;
    private float targetXPosition;
    private bool isSliding;
    private float[] lanePositions = new float[] { -3.75f, -1.32f, 1.26f, 3.86f }; // Same lanes as NPC cars

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = maxSpeed;
        targetSpeed = maxSpeed;
        // Start in a random lane
        targetXPosition = lanePositions[Random.Range(0, lanePositions.Length)];
        transform.position = new Vector3(targetXPosition, transform.position.y, transform.position.z);
    }

    void Update()
    {
        CheckForObstacles();
        MoveForward();
        HandleSliding();
    }

    void CheckForObstacles()
    {
        // Cast rays in multiple directions to detect NPC cars
        RaycastHit2D hitForward = Physics2D.Raycast(transform.position, transform.up, detectionDistance, npcLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, -transform.right, sideDetectionDistance, npcLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, transform.right, sideDetectionDistance, npcLayer);

        if (hitForward.collider != null)
        {
            // Calculate distance to the NPC car
            float distanceToObstacle = hitForward.distance;

            // Adjust speed based on distance to obstacle
            if (distanceToObstacle < safeDistance)
            {
                targetSpeed = minSpeed;

                // Decide which direction to slide
                if (!isSliding)
                {
                    if (hitLeft.collider == null && hitRight.collider != null)
                    {
                        SlideLeft();
                    }
                    else if (hitRight.collider == null && hitLeft.collider != null)
                    {
                        SlideRight();
                    }
                    else if (hitLeft.collider == null && hitRight.collider == null)
                    {
                        // Both sides are clear, randomly choose one
                        if (Random.value > 0.5f)
                            SlideLeft();
                        else
                            SlideRight();
                    }
                }
            }
            else
            {
                float speedFactor = Mathf.Clamp01(distanceToObstacle / detectionDistance);
                targetSpeed = Mathf.Lerp(minSpeed, maxSpeed, speedFactor);
            }
        }
        else
        {
            targetSpeed = maxSpeed;
        }

        // Smoothly adjust current speed
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed,
            (currentSpeed > targetSpeed ? deceleration : acceleration) * Time.deltaTime);

        // Debug visualization
        Debug.DrawRay(transform.position, transform.up * detectionDistance, Color.red);
        Debug.DrawRay(transform.position, -transform.right * sideDetectionDistance, Color.yellow);
        Debug.DrawRay(transform.position, transform.right * sideDetectionDistance, Color.yellow);
    }

    void MoveForward()
    {
        // Keep the car moving forward
        rb.linearVelocity = Vector2.up * currentSpeed;
    }

    void HandleSliding()
    {
        if (isSliding)
        {
            // Calculate direction to target position
            float direction = Mathf.Sign(targetXPosition - transform.position.x);

            // Move towards target position
            float newX = Mathf.MoveTowards(transform.position.x, targetXPosition, slideSpeed * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            // Tilt the car in the direction of movement
            float targetAngle = -direction * maxSlideAngle;
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.Euler(0, 0, targetAngle),
                Time.deltaTime * slideSpeed);

            // Check if we've reached the target position
            if (Mathf.Abs(transform.position.x - targetXPosition) < 0.1f)
            {
                isSliding = false;
                // Return to straight orientation
                transform.rotation = Quaternion.Lerp(transform.rotation,
                    Quaternion.identity,
                    Time.deltaTime * slideSpeed);
            }
        }
    }

    void SlideLeft()
    {
        // Find current lane index
        int currentLaneIndex = System.Array.IndexOf(lanePositions, targetXPosition);
        if (currentLaneIndex > 0)
        {
            targetXPosition = lanePositions[currentLaneIndex - 1];
            isSliding = true;
        }
    }

    void SlideRight()
    {
        // Find current lane index
        int currentLaneIndex = System.Array.IndexOf(lanePositions, targetXPosition);
        if (currentLaneIndex < lanePositions.Length - 1)
        {
            targetXPosition = lanePositions[currentLaneIndex + 1];
            isSliding = true;
        }
    }
}