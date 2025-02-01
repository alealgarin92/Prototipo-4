using UnityEngine;
using UnityEngine.Rendering;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefap;
    [SerializeField] private GameObject powerupPrefap;
    [SerializeField] private int enemyCount;
    private float spawnRange = 9.0f;
    private int waveNumber = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i=0; i<enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefap, GenerateSpawnPosition(), enemyPrefap.transform.rotation);
        }
    }

    void SpawnPowerup()
    {
        Instantiate(powerupPrefap, GenerateSpawnPosition(), powerupPrefap.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPositionX, 0, spawnPositionZ);

        return randomPos;
    }
}
