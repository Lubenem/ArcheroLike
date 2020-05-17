using UnityEngine;

public class EnemyFighter : MonoBehaviour
{
    public GameObject fireballPrefab;
    private GameObject fireball;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Hit()
    {
        if (player == null) return;
        fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);
        fireball.transform.LookAt(player.GetComponent<Player>().enemyTargetPos.transform.position);
    }

    public void TripleHit()
    {
        if (player == null) return;
        fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);
        fireball.transform.LookAt(player.GetComponent<Player>().enemyTargetPos.transform.position);
        fireball.transform.Rotate(0, 30, 0);

        fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);
        fireball.transform.LookAt(player.GetComponent<Player>().enemyTargetPos.transform.position);


        fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);
        fireball.transform.LookAt(player.GetComponent<Player>().enemyTargetPos.transform.position);
        fireball.transform.Rotate(0, -30, 0);
    }
}