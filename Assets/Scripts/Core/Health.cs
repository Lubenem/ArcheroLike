using UnityEngine;
using UnityEngine.UIElements;

public class Health : MonoBehaviour
{
    public float health = 10;
    private float maxHealth;
    public GameObject healthBar;

    private void Start()
    {
        maxHealth = health;
    }

    public void takeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, health);
        Slider slider = healthBar.GetComponent<Slider>();
        if (slider != null) slider.value = health / maxHealth;
    }

    private void Update()
    {
        if (health <= 0) Destroy(this.gameObject);
    }

}