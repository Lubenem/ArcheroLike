using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [HideInInspector] public Vector3 velocity;
    public Joystick joystick;
    public float speed = 3;
    private Transform nearestEnemy;

    private void Update()
    {
        velocity = new Vector3(joystick.Horizontal, 0, joystick.Vertical) * -1;
        nearestEnemy = GetNearestEnemy();

        if (velocity != Vector3.zero)
        {
            transform.LookAt(transform.position + velocity);
            GetComponent<Animator>().SetBool("Attacking", false);
            GetComponent<Animator>().SetBool("Moving", true);
        }

        else if (nearestEnemy)
        {
            transform.LookAt(nearestEnemy);
            GetComponent<Animator>().SetBool("Moving", false);
            GetComponent<Animator>().SetBool("Attacking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Moving", false);
            GetComponent<Animator>().SetBool("Attacking", false);
        }
    }

    private Transform GetNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDist = Mathf.Infinity;
        GameObject target = null;

        if (enemies.Length <= 0) return null;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                target = enemy;
            }
        }
        return target.transform;
    }
}