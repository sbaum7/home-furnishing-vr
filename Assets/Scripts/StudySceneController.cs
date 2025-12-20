using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class StudySceneController : MonoBehaviour
{
    [Tooltip("Name of the scene that contains the actual matching gameplay.")]
    public string matchingSceneName = "LivingRoom";

    // This will be hooked to the XR Simple Interactable's select event
    public void StartMatchingScene(SelectEnterEventArgs args)
    {
        LoadMatchingScene();
    }

    // Overload so we can also call it without event args
    public void LoadMatchingScene()
    {
        Debug.Log("Loading matching scene: " + matchingSceneName);
        SceneManager.LoadScene(matchingSceneName);
    }
}
