using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}