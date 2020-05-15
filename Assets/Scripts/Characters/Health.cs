using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 10;

    public void takeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, health);
    }

    private void Update()
    {
        if (health <= 0) Destroy(this.gameObject);
    }

}