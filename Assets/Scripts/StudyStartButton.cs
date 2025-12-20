using UnityEngine;
using UnityEngine.SceneManagement;

public class StudyStartButton : MonoBehaviour
{
    [Header("Scene To Load")]
    [Tooltip("Exact name of the scene to load when this button is selected")]
    public string sceneToLoad;

    public void StartMatching()
    {
        if (string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.LogWarning("SceneToLoad is not set on " + gameObject.name);
            return;
        }

        Debug.Log("Loading scene: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}
