using UnityEngine;
using System.Collections;
using System;

public class PolzunMover : MonoBehaviour
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
    }

    void Update()
    {
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
        timeSinceLastAttack = 0;
        Debug.Log("Hit");
        player.GetComponent<Health>().takeDamage(damage);
    }
}