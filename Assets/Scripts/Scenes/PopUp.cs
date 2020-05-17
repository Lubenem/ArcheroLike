using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour
{
    public bool isPlayerAlive = true;
    public GameObject arrow;
    public Text txt;

    private void Start()
    {
        isPlayerAlive = true;
    }

    private void Update()
    {
        if (!isPlayerAlive)
        {
            GetComponent<Animator>().enabled = true;
        }
        if (SceneManager.GetActiveScene().name == "Arena1" && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            arrow.SetActive(true);
        }
        if (SceneManager.GetActiveScene().name == "Arena2" && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            GetComponent<Animator>().enabled = true;
            txt.text = "You win!";
        }
    }
}