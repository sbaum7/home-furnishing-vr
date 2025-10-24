using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Dropdown roomDropdown;  // Dropdown for selecting room (e.g. Bedroom, Kitchen)
    public TMP_Dropdown otherDropdown; // Optional: another dropdown for difficulty/settings
    public Toggle optionToggle;        // Optional toggle
    public Button startButton;         // Start Game button
    public Button quitButton;          // Quit button (optional)

    private string selectedRoomScene;

    void Start()
    {
        // Populate dropdown with room scene options
        roomDropdown.ClearOptions();
        roomDropdown.AddOptions(new System.Collections.Generic.List<string> {
      "Bedroom",
      "Living Room",
      //"Kitchen"
    });

        // Initialize selection
        selectedRoomScene = roomDropdown.options[roomDropdown.value].text;

        // Add listeners
        roomDropdown.onValueChanged.AddListener(OnRoomSelected);
        startButton.onClick.AddListener(OnStartGame);
        if (quitButton != null)
            quitButton.onClick.AddListener(OnQuitGame);
    }

    // Called when user changes room selection
    void OnRoomSelected(int index)
    {
        selectedRoomScene = roomDropdown.options[index].text;
        Debug.Log("Selected room: " + selectedRoomScene);
    }

    // Called when user clicks Start Game
    void OnStartGame()
    {
        if (string.IsNullOrEmpty(selectedRoomScene))
        {
            Debug.LogWarning("No room selected! Please select a room before starting.");
            return;
        }

        Debug.Log("Loading scene: " + selectedRoomScene);

        // Load the selected room scene
        SceneManager.LoadScene(selectedRoomScene);
    }

    // Optional: handle Quit button, not yet working
    void OnQuitGame()
    {
        Debug.Log("Quit Game clicked");
        Application.Quit();
    }
}

