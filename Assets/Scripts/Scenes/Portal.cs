using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Portal : MonoBehaviour
{
    public string sceneToLoad;
    public float oldPlayerHealth;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            oldPlayerHealth = GameObject.FindWithTag("Player").GetComponent<Health>().health;
            transform.parent = null;
            DontDestroyOnLoad(this.gameObject);
            yield return SceneManager.LoadSceneAsync(sceneToLoad);
            GameObject.FindWithTag("Player").GetComponent<Health>().health = oldPlayerHealth;
            Destroy(this.gameObject);
        }
    }
}