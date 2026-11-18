
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackCooldown = 1f;
    public float attackRange = 0.8f;

    private float nextAttackTime;
    private PlayerHealth player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
    }

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector2.Distance(
            transform.position, player.transform.position);

        if (distance <= attackRange &&
            Time.time >= nextAttackTime)
        {
            player.TakeDamage(damage);
            nextAttackTime = Time.time + attackCooldown;
        }
    }
}
