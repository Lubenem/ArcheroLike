using UnityEngine;
using System.Collections;

public class Letun : MonoBehaviour
{
    private bool isMoving;
    private GameObject player;
    public float speed = 4;
    public float timeToFly = 1;
    public float timeToAttack = 1;


    private void Start()
    {
        isMoving = true;
        player = GameObject.FindWithTag("Player");
        StartCoroutine(Flying());
    }

    private IEnumerator Flying()
    {
        while (true)
        {
            updateRotation();
            isMoving = true;
            yield return new WaitForSeconds(timeToFly);
            isMoving = false;
            Attack();
            yield return new WaitForSeconds(timeToAttack);
        }
    }

    private void updateRotation()
    {
        transform.Rotate(new Vector3(transform.rotation.x, Random.Range(0, 360), transform.rotation.z));
    }

    private void Attack()
    {
        GetComponent<EnemyFighter>().Hit();
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}