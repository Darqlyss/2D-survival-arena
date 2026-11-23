
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthText()
    {
        healthText.text = "HEALTH: " + currentHealth + "/" + maxHealth;
    }

    void Die()
    {
    GameManager gameManager = FindFirstObjectByType<GameManager>();

    if (gameManager != null)
    {
        gameManager.GameOver();
    }
    }
}
