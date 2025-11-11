using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsControl : MonoBehaviour
{
    [Header("Tab Buttons")]
    public GameObject tabbutton1;  // Sofa tab button
    public GameObject tabbutton2;  // Table tab button
    public GameObject tabbutton3;  // Bed tab button

    [Header("Tab Content Panels")]
    public GameObject tabcontent1; // Sofa tab panel
    public GameObject tabcontent2; // Table tab panel
    public GameObject tabcontent3; // Bed tab panel

    [Header("Sofa Prefabs")]
    public GameObject[] sofaPrefabs; // Assign sofa prefabs here

    [Header("Table Prefabs")]
    public GameObject[] tablePrefabs; // Assign table prefabs here

    [Header("Bed Prefabs")]
    public GameObject[] bedPrefabs; // Assign bed prefabs here

    [Header("Spawn Settings")]
    public Transform spawnPoint;     // Where furniture will appear

    private GameObject currentFurniture; // Keeps track of the last spawned furniture

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Hide all tabs at once
    public void HideAllTabs()
    {
        tabcontent1.SetActive(false);
        tabcontent2.SetActive(false);
        tabcontent3.SetActive(false);
    }

    // Show Sofa tab
    public void ShowTab1()
    {
        HideAllTabs();
        tabcontent1.SetActive(true);
    }

    // Show Table tab
    public void ShowTab2()
    {
        HideAllTabs();
        tabcontent2.SetActive(true);
    }

    // Show Bed tab
    public void ShowTab3()
    {
        HideAllTabs();
        tabcontent3.SetActive(true);
    }

    // Spawn sofa from sofaPrefabs[]
    public void SpawnSofa(int prefabIndex)
    {
        SpawnFurniture(sofaPrefabs, prefabIndex, "Sofa");
    }

    // Spawn table from tablePrefabs[]
    public void SpawnTable(int prefabIndex)
    {
        SpawnFurniture(tablePrefabs, prefabIndex, "Table");
    }

    // Spawn bed from bedPrefabs[]
    public void SpawnBed(int prefabIndex)
    {
        SpawnFurniture(bedPrefabs, prefabIndex, "Bed");
    }

    // Generalized spawn function
    private void SpawnFurniture(GameObject[] prefabArray, int prefabIndex, string typeName)
    {
        if (prefabArray == null || prefabArray.Length == 0)
        {
            Debug.LogWarning($"No {typeName} prefabs assigned!");
            return;
        }

        if (prefabIndex < 0 || prefabIndex >= prefabArray.Length)
        {
            Debug.LogWarning($"Invalid {typeName} prefab index!");
            return;
        }

        // Destroy previously spawned furniture
        if (currentFurniture != null)
        {
            Destroy(currentFurniture);
        }

        // Spawn new furniture
        currentFurniture = Instantiate(prefabArray[prefabIndex], spawnPoint.position, spawnPoint.rotation);
        Debug.Log($"Spawned {typeName}: " + prefabArray[prefabIndex].name);
    }
}
