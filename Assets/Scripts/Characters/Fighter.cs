using UnityEngine;

public class Fighter : MonoBehaviour
{
    public GameObject fireballPrefab;
    private GameObject fireball;
    public Transform fireballTrans;

    public void Hit()
    {
        fireball = Instantiate(fireballPrefab, fireballTrans.position, transform.rotation);
        fireball.transform.LookAt(GetComponent<Mover>().nearestEnemy.position);
    }
}