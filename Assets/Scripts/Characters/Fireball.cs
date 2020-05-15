using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 3;
    private GameObject player;
    public float maxDist = 10;
    private bool isColliding;
    public float damage = 5;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        isColliding = false;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.transform.position) >= maxDist)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isColliding) return;

        if (other.tag == "Enemy")
        {
            isColliding = true;
            other.GetComponent<Health>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}