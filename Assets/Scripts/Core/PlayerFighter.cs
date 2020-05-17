using UnityEngine;

public class PlayerFighter : MonoBehaviour
{
    public GameObject fireballPrefab;
    private GameObject fireball;
    public Transform fireballPos;

    public void Hit()
    {
        fireball = Instantiate(fireballPrefab, fireballPos.position, transform.rotation);
        fireball.transform.LookAt(GetComponent<Player>().nearestEnemy.position);
    }

    public void FootL()
    {

    }
    public void FootR()
    {

    }
}