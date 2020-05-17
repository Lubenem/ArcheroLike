using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string SceneToLoad;

    public void Load()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}