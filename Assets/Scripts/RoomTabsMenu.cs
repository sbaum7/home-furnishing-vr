using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class RoomTabsMenu : MonoBehaviour
{
    [Header("UI Buttons")]
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;

    [Header("Prefabs")]
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;

    [Header("Spawn Settings")]
    public Transform spawnPoint;

    [Tooltip("How far in front of the spawn point objects appear")]
    public float spawnForwardOffset = 0.0f;

    [Tooltip("How far UP from the spawn point objects appear (fixes floor clipping)")]
    public float spawnUpOffset = 0.3f;

    [Header("Menu Settings")]
    public GameObject menuPanel;

    // Track one spawned object PER prefab
    private Dictionary<GameObject, GameObject> spawnedByPrefab = new Dictionary<GameObject, GameObject>();

    public InputActionProperty menuAction;

    void OnEnable()
    {
        if (menuAction.action != null)
        {
            menuAction.action.performed += OnMenuPressed;
            menuAction.action.Enable();
        }
    }

    void OnDisable()
    {
        if (menuAction.action != null)
            menuAction.action.performed -= OnMenuPressed;
    }

    void Start()
    {
        if (button1) button1.onClick.AddListener(() => Spawn(prefab1, "Prefab 1"));
        if (button2) button2.onClick.AddListener(() => Spawn(prefab2, "Prefab 2"));
        if (button3) button3.onClick.AddListener(() => Spawn(prefab3, "Prefab 3"));
        if (button4) button4.onClick.AddListener(() => Spawn(prefab4, "Prefab 4"));
        if (button5) button5.onClick.AddListener(() => Spawn(prefab5, "Prefab 5"));
        if (button6) button6.onClick.AddListener(() => Spawn(prefab6, "Prefab 6"));

        if (menuPanel != null)
            menuPanel.SetActive(false);
    }

    private void OnMenuPressed(InputAction.CallbackContext ctx)
    {
        ToggleMenu();
    }

    void ToggleMenu()
    {
        if (menuPanel != null)
            menuPanel.SetActive(!menuPanel.activeSelf);
    }

    void Spawn(GameObject prefab, string name)
    {
        if (prefab == null)
        {
            Debug.LogWarning($"{name} is not assigned!");
            return;
        }

        if (spawnPoint == null)
        {
            Debug.LogWarning("SpawnPoint is not assigned!");
            return;
        }

        // Replace ONLY the existing object of this prefab type
        if (spawnedByPrefab.TryGetValue(prefab, out GameObject existing) && existing != null)
            Destroy(existing);

        // ✅ Fix floor clipping: spawn a bit above the floor
        Vector3 spawnPos =
            spawnPoint.position +
            spawnPoint.forward * spawnForwardOffset +
            Vector3.up * spawnUpOffset;

        GameObject spawned = Instantiate(prefab, spawnPos, spawnPoint.rotation);
        spawnedByPrefab[prefab] = spawned;

        Debug.Log($"Spawned {name}");
    }
}
