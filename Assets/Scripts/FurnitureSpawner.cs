using UnityEngine;

public class FurnitureSpawner : MonoBehaviour
{
    public Transform spawnPoint;    // The fixed location to spawn items
    private GameObject currentObject;

    public void SpawnFurniture(GameObject prefab)
    {
        if (prefab == null || spawnPoint == null)
        {
            Debug.LogWarning("Spawner missing prefab or spawnPoint.");
            return;
        }

        // Remove the previous spawned object
        if (currentObject != null)
        {
            Destroy(currentObject);
            currentObject = null;
        }

        // Spawn the new furniture item
        currentObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void DeleteCurrent()
    {
        if (currentObject != null)
        {
            Destroy(currentObject);
            currentObject = null;
        }
    }
}
