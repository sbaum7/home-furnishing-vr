using UnityEngine;
using UnityEngine.UI;

public class SimpleSpawn : MonoBehaviour
{
    [Header("Furniture Prefabs")]
    public GameObject[] furniturePrefabs; // Assign all prefabs you want to test

    [Header("Spawn Settings")]
    public Transform spawnPoint; // Where the furniture will appear

    private GameObject currentFurniture;

    // Called by UI button, pass prefab index
    public void SpawnFurniture(int prefabIndex)
    {
        if (furniturePrefabs == null || furniturePrefabs.Length == 0)
        {
            Debug.LogWarning("No furniture prefabs assigned!");
            return;
        }

        if (prefabIndex < 0 || prefabIndex >= furniturePrefabs.Length)
        {
            Debug.LogWarning("Invalid prefab index!");
            return;
        }

        // Remove previous spawned object
        if (currentFurniture != null)
            Destroy(currentFurniture);

        // Spawn the prefab at the spawn point with default rotation
        currentFurniture = Instantiate(
            furniturePrefabs[prefabIndex],
            spawnPoint.position,
            Quaternion.identity
        );

        Debug.Log("Spawned: " + furniturePrefabs[prefabIndex].name);
    }
}
