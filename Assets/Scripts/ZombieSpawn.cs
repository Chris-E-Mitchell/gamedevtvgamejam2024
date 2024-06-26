using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawners;
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private float spawnTime = 2f;

    private float spawnTimer;
    private bool isSpawning = true;

    private void Start()
    {
        SpawnEnemy();

        spawnTimer = spawnTime;
    }

    private void Update()
    {
        if (!isSpawning) { return; }
        
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            SpawnEnemy();
            spawnTimer = spawnTime;
        }
    }

    private void SpawnEnemy()
    {
        int spawner = Random.Range(0, spawners.Length);
        int enemy = Random.Range(0, enemies.Length);

        Instantiate(enemies[enemy], spawners[spawner].position, Quaternion.identity);
    }

    public void SetSpawning(bool isSpawning)
    {
        this.isSpawning = isSpawning;
    }
}
