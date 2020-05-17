using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 10;
    public float maxHealth = 10;
    public GameObject healthBar;

    public void takeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, health);
    }

    private void updateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.GetComponent<Slider>().value = health / maxHealth;
        }
    }

    private void Update()
    {
        if (health <= 0) Destroy(this.gameObject);
        updateHealthBar();
    }
}