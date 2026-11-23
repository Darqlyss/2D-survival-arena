
using System.Collections;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public TextMeshProUGUI waveText;

    public int currentWave = 0;
    public int enemiesPerWave = 5;
    public float spawnDelay = 1f;
    public float timeBetweenWaves = 3f;

    private int enemiesAlive = 0;
    private bool isSpawning = false;

    void Start()
    {
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        currentWave++;

        int enemyCount = enemiesPerWave + (currentWave - 1) * 3;

        waveText.text = "WAVE " + currentWave;

        Debug.Log("Wave " + currentWave + " started!");

        isSpawning = true;

        for (int i = 0; i < enemyCount; i++)
        {
            enemySpawner.SpawnEnemy(currentWave);
            enemiesAlive++;

            yield return new WaitForSeconds(spawnDelay);
        }

        isSpawning = false;

        if (enemiesAlive <= 0)
        {
            StartCoroutine(NextWave());
        }
    }

    public void EnemyKilled()
    {
        enemiesAlive--;

        if (enemiesAlive <= 0 && !isSpawning)
        {
            StartCoroutine(NextWave());
        }
    }

    IEnumerator NextWave()
    {
        Debug.Log("Wave " + currentWave + " completed!");

        yield return new WaitForSeconds(timeBetweenWaves);

        StartCoroutine(StartWave());
    }
}
