using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int spawnCount = 5;
    [SerializeField] float spawnRange = 1f;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 randomPos = transform.position + new Vector3(
                Random.Range(-spawnRange, spawnRange),
                1,
                Random.Range(-spawnRange, spawnRange)
            );

            Instantiate(enemyPrefab, randomPos, Quaternion.identity);
            WaitForSeconds wait = new WaitForSeconds(3.0f);
        }
    }
}