
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject tankEnemyPrefab;

    public Transform[] spawnPoints;
    public float minSpawnDistance = 3f;

    private Transform player;

    void Awake()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    public void SpawnEnemy(int wave)
    {
        if (player == null || spawnPoints.Length == 0)
            return;

        int startIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int index = (startIndex + i) % spawnPoints.Length;
            Transform spawnPoint = spawnPoints[index];

            if (spawnPoint == null)
                continue;

            float distance = Vector2.Distance(
                spawnPoint.position,
                player.position
            );

            if (distance >= minSpawnDistance)
            {
                GameObject enemyToSpawn = enemyPrefab;

                if (wave >= 2 && Random.Range(0, 4) == 0)
                {
                    enemyToSpawn = tankEnemyPrefab;
                }

                if (enemyToSpawn != null)
                {
                    Instantiate(
                        enemyToSpawn,
                        spawnPoint.position,
                        Quaternion.identity
                    );
                }

                return;
            }
        }
    }
}
