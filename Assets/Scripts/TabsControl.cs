using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsControl : MonoBehaviour
{
    [Header("Tab Buttons")]
    public GameObject tabbutton1;  // Sofa tab button
    public GameObject tabbutton2;  // Table tab button
    public GameObject tabbutton3;  // Bed tab button
    public GameObject tabbutton4;  // Props tab button  

    [Header("Tab Content Panels")]
    public GameObject tabcontent1; // Sofa tab panel
    public GameObject tabcontent2; // Table tab panel
    public GameObject tabcontent3; // Bed tab panel
    public GameObject tabcontent4; // Props tab panel 

    [Header("Sofa Prefabs")]
    public GameObject[] sofaPrefabs;

    [Header("Table Prefabs")]
    public GameObject[] tablePrefabs;

    [Header("Bed Prefabs")]
    public GameObject[] bedPrefabs;

    [Header("Props Prefabs")]     
    public GameObject[] propsPrefabs;

    [Header("Spawn Settings")]
    public Transform spawnPoint;

    [Header("Bed Forward Direction")]
    public Vector3 bedForward = Vector3.forward;

    private GameObject currentFurniture;
    private Quaternion bedRotation;

    void Start()
    {
        Vector3 flatDirection = new Vector3(bedForward.x, 0f, bedForward.z);
        bedRotation = Quaternion.LookRotation(flatDirection);
        bedRotation.x = 0f;
        bedRotation.z = 0f;
    }

    // Hide all tabs at once
    public void HideAllTabs()
    {
        tabcontent1.SetActive(false);
        tabcontent2.SetActive(false);
        tabcontent3.SetActive(false);
        tabcontent4.SetActive(false);  // << NEW
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

    // Show Props tab   << NEW
    public void ShowTab4()
    {
        HideAllTabs();
        tabcontent4.SetActive(true);
    }

    // Spawn sofa
    public void SpawnSofa(int prefabIndex)
    {
        SpawnFurniture(sofaPrefabs, prefabIndex, "Sofa");
    }

    // Spawn table
    public void SpawnTable(int prefabIndex)
    {
        SpawnFurniture(tablePrefabs, prefabIndex, "Table");
    }

    // Spawn bed
    public void SpawnBed(int prefabIndex)
    {
        SpawnFurniture(bedPrefabs, prefabIndex, "Bed");
    }

    // Spawn props (NEW)
    public void SpawnProps(int prefabIndex)
    {
        SpawnFurniture(propsPrefabs, prefabIndex, "Props");
    }

    // Shared spawning function
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

        if (currentFurniture != null)
        {
            Destroy(currentFurniture);
        }

        Vector3 forward = Vector3.forward;
        Quaternion rotation = Quaternion.identity;

        if (typeName == "Sofa")
        {
            forward = Vector3.forward;
            Vector3 flat = new Vector3(forward.x, 0f, forward.z);
            rotation = Quaternion.LookRotation(flat);
        }
        else if (typeName == "Table")
        {
            forward = Vector3.right;
            Vector3 flat = new Vector3(forward.x, 0f, forward.z);
            rotation = Quaternion.LookRotation(flat);
        }
        else if (typeName == "Bed")
        {
            rotation = bedRotation;
        }
        else if (typeName == "Props")
        {
            // Props face default forward unless changed later
            forward = Vector3.forward;
            Vector3 flat = new Vector3(forward.x, 0f, forward.z);
            rotation = Quaternion.LookRotation(flat);
        }

        currentFurniture = Instantiate(prefabArray[prefabIndex], spawnPoint.position, rotation);
        Debug.Log($"Spawned {typeName}: " + prefabArray[prefabIndex].name);
    }
}
