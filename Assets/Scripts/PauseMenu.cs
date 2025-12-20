using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI References")]
    public Button resumeButton;
    public Button quitButton;

    [Header("Scene References")]
    public string resumeSceneName = "";       // Optional: scene to resume, or leave empty if staying in current scene
    public string quitSceneName = "Easy"; // Scene to load when quitting (like Start Menu)

    void Start()
    {
        // Add button listeners
        if (resumeButton != null)
            resumeButton.onClick.AddListener(OnResumeClicked);

        if (quitButton != null)
            quitButton.onClick.AddListener(OnQuitClicked);
    }

    // Called when Resume button is clicked
    void OnResumeClicked()
    {
        Time.timeScale = 1f; // Resume game time
        Debug.Log("Game Resumed");

        // Optional: reload current scene or load a specific scene
        if (!string.IsNullOrEmpty(resumeSceneName))
        {
            SceneManager.LoadScene(resumeSceneName);
        }
    }

    // Called when Quit button is clicked
    void OnQuitClicked()
    {
        Debug.Log("Quitting to scene: " + quitSceneName);
        Time.timeScale = 1f; // Reset time scale before changing scene
        SceneManager.LoadScene(quitSceneName);
    }
}
