using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 30;

    private int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }



    void Die()
    {
    WaveManager waveManager = FindFirstObjectByType<WaveManager>();

    if (waveManager != null)
    {
        waveManager.EnemyKilled();
    }

    ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();

    if (scoreManager != null)
    {
        scoreManager.AddScore(10);
    }

    Destroy(gameObject);
    }


}
