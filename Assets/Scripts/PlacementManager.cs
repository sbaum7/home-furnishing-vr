using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] private List<PlacementChecker> placements; // Drag all your PlacementCheckers (or their GameObjects) here
    [SerializeField] private ParticleSystem confettiPrefab; // Your confetti prefab
    [SerializeField] private string nextSceneName = "NextScene"; // Change to your actual next scene name

    private Dictionary<PlacementChecker, bool> placementStatus = new Dictionary<PlacementChecker, bool>();

    void Start()
    {
        foreach (var placement in placements)
        {
            placementStatus[placement] = false;
        }
    }

    public void UpdatePlacement(PlacementChecker checker, bool isPlaced)
    {
        if (placementStatus.ContainsKey(checker))
        {
            placementStatus[checker] = isPlaced;

            if (isPlaced == false) return; // Early out if removed

            CheckAllPlaced();
        }
    }

    private void CheckAllPlaced()
    {
        foreach (var status in placementStatus.Values)
        {
            if (!status) return;
        }

        // All placed!
        TriggerConfetti();
        Invoke(nameof(LoadNextScene), 2f); // Give time for confetti
    }

    private void TriggerConfetti()
    {
        foreach (var placement in placements)
        {
            if (confettiPrefab != null)
            {
                ParticleSystem confetti = Instantiate(confettiPrefab, placement.transform.position, Quaternion.identity);
                confetti.Play();
                Debug.Log("Confetti triggered!");
                Destroy(confetti.gameObject, 6f);
            }
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}