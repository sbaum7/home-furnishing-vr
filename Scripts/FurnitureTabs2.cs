using System.Collections.Generic;
using UnityEngine;

public class FurnitureTabs2 : MonoBehaviour
{
    [Header("Tab Buttons")]
    public GameObject tabbutton1;
    public GameObject tabbutton2;
    public GameObject tabbutton3;

    [Header("Tab Contents")]
    public GameObject tabcontent1; // Sofa tab
    public GameObject tabcontent2; // Chair tab
    public GameObject tabcontent3; // Table tab

    [Header("Furniture Prefabs")]
    public List<GameObject> sofaPrefabs; // List of sofa prefabs to display
    public Transform sofaParent;         // Parent object inside tabcontent1 to hold sofas
    public Vector3 startPosition = new Vector3(0, 0, 0);
    public float spacing = 2f;           // Distance between displayed sofas

    void Start()
    {
        HideAllTabs();
    }

    void HideAllTabs()
    {
        tabcontent1.SetActive(false);
        tabcontent2.SetActive(false);
        tabcontent3.SetActive(false);
    }

    public void ShowTab1() // Sofa tab
    {
        HideAllTabs();
        tabcontent1.SetActive(true);
        DisplaySofas();
    }

    public void ShowTab2()
    {
        HideAllTabs();
        tabcontent2.SetActive(true);
    }

    public void ShowTab3()
    {
        HideAllTabs();
        tabcontent3.SetActive(true);
    }

    void DisplaySofas()
    {
        // Clear previous sofas first
        foreach (Transform child in sofaParent)
        {
            Destroy(child.gameObject);
        }

        // Spawn all sofa prefabs
        for (int i = 0; i < sofaPrefabs.Count; i++)
        {
            Vector3 pos = startPosition + new Vector3(i * spacing, 0, 0);
            Instantiate(sofaPrefabs[i], pos, Quaternion.identity, sofaParent);
        }
    }
}
