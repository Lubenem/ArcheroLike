using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Vector3 velocity;
    [HideInInspector] public Transform nearestEnemy;
    [HideInInspector] public Transform nearestLetun;
    public Transform enemyTargetPos;
    public Joystick joystick;
    public float speed = 3;
    RaycastHit hit;
    public Transform rayPos;
    public GameObject popUp;

    private void Update()
    {
        velocity = new Vector3(joystick.Horizontal, 0, joystick.Vertical) * -1;
        nearestEnemy = GetNearest(GameObject.FindGameObjectsWithTag("Enemy"));
        nearestLetun = GetNearest(GameObject.FindGameObjectsWithTag("Letun"));

        if (velocity != Vector3.zero)
        {
            transform.LookAt(transform.position + velocity);
            GetComponent<Animator>().SetBool("Attacking", false);
            GetComponent<Animator>().SetBool("Moving", true);
        }
        else if (isVisible(nearestEnemy))
        {
            transform.LookAt(new Vector3(nearestEnemy.position.x, 0, nearestEnemy.position.z));
            GetComponent<Animator>().SetBool("Moving", false);
            GetComponent<Animator>().SetBool("Attacking", true);
        }
        else if (nearestLetun != null)
        {
            transform.LookAt(new Vector3(nearestLetun.position.x, 0, nearestLetun.position.z));
            nearestEnemy = nearestLetun;
            GetComponent<Animator>().SetBool("Moving", false);
            GetComponent<Animator>().SetBool("Attacking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Moving", false);
            GetComponent<Animator>().SetBool("Attacking", false);
        }

        if (nearestEnemy != null) Debug.DrawRay(rayPos.position, nearestEnemy.position - rayPos.position);
    }

    private bool isVisible(Transform nearestEnemy)
    {
        if (nearestEnemy == null) return false;
        Physics.Raycast(rayPos.position, nearestEnemy.position - rayPos.position, out hit);
        if (hit.transform.tag == "Enemy") return true;
        return false;
    }

    private Transform GetNearest(GameObject[] objects)
    {
        float minDist = Mathf.Infinity;
        GameObject target = null;

        if (objects.Length <= 0) return null;

        foreach (GameObject obj in objects)
        {
            float dist = Vector3.Distance(transform.position, obj.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                target = obj;
            }
        }
        return target.transform;
    }

    private void OnDestroy()
    {
        popUp.GetComponent<PopUp>().isPlayerAlive = false;
    }
}