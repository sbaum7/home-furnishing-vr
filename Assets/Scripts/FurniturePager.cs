using UnityEngine;
using UnityEngine.UI;

public class FurniturePager : MonoBehaviour
{
    [Header("UI Buttons")]
    public Button categoryButton1; // e.g., Living Room

    [Header("Furniture Categories")]
    public GameObject[] livingRoomPrefabs;  // 4 prefabs for living room
    public Transform[] spawnPoints;          // 4 spawn points for furniture

    private GameObject[] currentObjects;     // Tracks spawned objects

    void Start()
    {
        currentObjects = new GameObject[spawnPoints.Length];

        // Assign listener to category button
        categoryButton1.onClick.AddListener(() => SpawnCategory(livingRoomPrefabs));
    }

    void SpawnCategory(GameObject[] prefabs)
    {
        if (prefabs.Length != spawnPoints.Length)
        {
            Debug.LogWarning("Number of prefabs and spawn points do not match!");
            return;
        }

        // Destroy previously spawned objects
        for (int i = 0; i < currentObjects.Length; i++)
        {
            if (currentObjects[i] != null)
            {
                Destroy(currentObjects[i]);
            }
        }

        // Spawn new prefabs
        for (int i = 0; i < prefabs.Length; i++)
        {
            if (prefabs[i] != null)
            {
                currentObjects[i] = Instantiate(prefabs[i], spawnPoints[i].position, Quaternion.identity);
                Debug.Log($"Spawned {prefabs[i].name}");
            }
        }
    }
}
