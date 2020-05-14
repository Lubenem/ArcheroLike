using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [HideInInspector] public Vector3 velocity;
    public Joystick joystick;
    public float speed = 3;

    private void Update()
    {
        velocity = new Vector3(joystick.Horizontal, 0, joystick.Vertical) * -1;

        if (velocity != Vector3.zero)
        {
            transform.LookAt(transform.position + velocity);
            GetComponent<Animator>().SetBool("Moving", true);
        }
        else
        {
            transform.LookAt(GetNearestEnemy());
            GetComponent<Animator>().SetBool("Moving", false);
        }
    }

    private Transform GetNearestEnemy()
    {
        float minDist = Mathf.Infinity;
        GameObject target = null;

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
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