using UnityEngine;
using System.Collections;
using System;

public class Boss : MonoBehaviour
{
    private bool isMoving;
    private GameObject player;
    public float speed = 6;
    public float timeToWalk = 1;
    public float timeToAttack = 1;
    public float minDist = 0.5f;
    public float timeBetweenAttacks = 1;
    float timeSinceLastAttack;
    public float damage = 5;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(Routine());
    }

    private void Update()
    {
        transform.LookAt(player.transform);

        if (!isMoving) return;

        if (Vector3.Distance(transform.position, player.transform.position) > minDist)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            MeleeAttack();
        }
    }

    private IEnumerator Routine()
    {
        while (true)
        {
            isMoving = false;
            yield return new WaitForSeconds(1);
            int randomInt = UnityEngine.Random.Range(0, 3);
            if (randomInt == 0) yield return State1();
            if (randomInt == 1) yield return State2();
            if (randomInt == 2) yield return State3();
        }
    }

    private IEnumerator State1()
    {
        isMoving = true;
        yield return new WaitForSeconds(2f);
    }

    private IEnumerator State2()
    {
        isMoving = false;
        int count = 0;
        while (count < 3)
        {
            GetComponent<EnemyFighter>().Hit();
            yield return new WaitForSeconds(0.2f);
            count++;
        }
    }

    private IEnumerator State3()
    {
        isMoving = false;
        GetComponent<EnemyFighter>().TripleHit();
        yield return null;
    }

    private void MeleeAttack()
    {
        timeSinceLastAttack += Time.deltaTime;
        if (timeSinceLastAttack < timeBetweenAttacks) return;
        timeSinceLastAttack = 0;
        player.GetComponent<Health>().takeDamage(damage);
    }
}