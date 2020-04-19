using UnityEngine.SceneManagement;

/// <summary>
/// Manages scene transitions.
/// </summary>
public class LoadingManager : Singleton<LoadingManager>
{
    public void LoadNextScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1);
    }

    public void LoadPreviousScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex - 1);
    }
}