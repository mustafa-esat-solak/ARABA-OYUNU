using UnityEngine;
using System.Collections.Generic;

public class PathManager : MonoBehaviour
{
    public GameObject pathPrefab; // Reference to your path/road prefab
    public float pathLength = 10f; // Length of each path segment
    public float cleanupDistance = 20f; // Distance behind car to cleanup paths
    public int maxPaths = 2; // Maximum number of paths to maintain

    private Transform carTransform;
    private List<GameObject> activePaths = new List<GameObject>();
    private float lastPathY = 0f;

    void Start()
    {
        // Find the car in the scene
        carTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (carTransform == null)
        {
            Debug.LogError("Car not found! Make sure your car has the 'Player' tag.");
            return;
        }

        // Create initial paths
        CreateNewPath();
        CreateNewPath();
    }

    void Update()
    {
        if (carTransform == null) return;

        // Check if we need to create a new path
        if (carTransform.position.y > lastPathY + pathLength)
        {
            CreateNewPath();
            CleanupOldPaths();
        }
    }

    void CreateNewPath()
    {
        if (pathPrefab == null)
        {
            Debug.LogError("Path prefab not assigned!");
            return;
        }

        // Create new path at the current position
        Vector3 pathPosition = new Vector3(0f, lastPathY, 0f);
        GameObject newPath = Instantiate(pathPrefab, pathPosition, Quaternion.identity);
        activePaths.Add(newPath);

        // Update last path position
        lastPathY += pathLength;

        // Remove oldest path if we exceed max paths
        if (activePaths.Count > maxPaths)
        {
            GameObject oldestPath = activePaths[0];
            activePaths.RemoveAt(0);
            Destroy(oldestPath);
        }
    }

    void CleanupOldPaths()
    {
        // Remove paths that are too far behind the car
        for (int i = activePaths.Count - 1; i >= 0; i--)
        {
            GameObject path = activePaths[i];
            if (path != null && carTransform.position.y - path.transform.position.y > cleanupDistance)
            {
                activePaths.RemoveAt(i);
                Destroy(path);
            }
        }
    }
}