using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenuManager : MonoBehaviour
{
    [Header("Menu UI")]
    public GameObject menuPanel;     // The whole menu panel
    public Button resumeButton;
    public Button mainMenuButton;
    public Button quitButton;

    private bool isMenuOpen = false;

    void Start()
    {
        // Hide the menu at the start
        menuPanel.SetActive(false);

        // Hook up buttons
        resumeButton.onClick.AddListener(CloseMenu);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        // Press ESC to toggle menu visibility
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen)
                CloseMenu();
            else
                OpenMenu();
        }
    }

    void OpenMenu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        isMenuOpen = true;
    }

    void CloseMenu()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f; // Resume game
        isMenuOpen = false;
    }

    // ui for this not implemented yet
    void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu"); 
    }

    void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}


