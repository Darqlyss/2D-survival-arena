
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public float spawnInterval = 3f;
    public float minSpawnDistance = 3f;

    private Transform player;
    private float nextSpawnTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    public void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
            return;

        int startIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int index = (startIndex + i) % spawnPoints.Length;
            Transform spawnPoint = spawnPoints[index];

            float distance = Vector2.Distance(
                spawnPoint.position, player.position);

            if (distance >= minSpawnDistance)
            {
                Instantiate(enemyPrefab,
                    spawnPoint.position,
                    Quaternion.identity);

                return;
            }
        }
    }
}
