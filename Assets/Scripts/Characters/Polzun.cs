using UnityEngine;

public class Polzun : MonoBehaviour
{
    public float speed = 4;
    public float minDist = 0.5f;
    private GameObject player;
    public float damage = 5;
    public float timeBetweenAttacks = 1;
    float timeSinceLastAttack;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        timeSinceLastAttack = Mathf.Infinity;
    }

    void Update()
    {
        if (player == null) return;
        transform.LookAt(player.transform);

        if (Vector3.Distance(transform.position, player.transform.position) > minDist)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            Attack();
        }
    }

    private void Attack()
    {
        timeSinceLastAttack += Time.deltaTime;
        if (timeSinceLastAttack < timeBetweenAttacks) return;
        player.GetComponent<Health>().takeDamage(damage);
        timeSinceLastAttack = 0;
    }
}