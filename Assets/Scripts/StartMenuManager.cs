using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class StartMenuManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Dropdown diffDropdown;  // Easy/Medium/Hard dropdown
    public Toggle optionToggle;        // Hints toggle
    public Button startButton;         // Start Game button
    public Button quitButton;          // Quit button

    [Header("Scene Names (No Hints)")]
    public string easyScene = "LivingRoom";
    public string mediumScene = "BedRoom";
    public string hardScene = "Kitchen";

    [Header("Scene Names (Hints On)")]
    public string easyHintsScene = "LivingRoomHints";
    public string mediumHintsScene = "BedRoomHints";
    public string hardHintsScene = "KitchenHints";

    void Start()
    {
        // Populate dropdown labels
        diffDropdown.ClearOptions();
        diffDropdown.AddOptions(new List<string> { "Easy", "Medium", "Hard" });

        // Button listeners
        startButton.onClick.AddListener(OnStartGame);

        if (quitButton != null)
            quitButton.onClick.AddListener(OnQuitGame);
    }

    void OnStartGame()
    {
        bool hintsOn = (optionToggle != null && optionToggle.isOn);
        int idx = diffDropdown.value; // 0=Easy, 1=Medium, 2=Hard

        string sceneToLoad;

        if (!hintsOn)
        {
            sceneToLoad = idx == 0 ? easyScene
                      : idx == 1 ? mediumScene
                      : hardScene;
        }
        else
        {
            sceneToLoad = idx == 0 ? easyHintsScene
                      : idx == 1 ? mediumHintsScene
                      : hardHintsScene;
        }

        Debug.Log($"Loading scene: {sceneToLoad} (hintsOn={hintsOn})");
        SceneManager.LoadScene(sceneToLoad);
    }

    void OnQuitGame()
    {
        Debug.Log("Quit Game clicked");
        Application.Quit();
    }
}
