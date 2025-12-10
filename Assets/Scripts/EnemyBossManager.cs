using UnityEngine;

public class EnemyBossManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnDelay = 5f; // Kaç saniye sonra spawn edilsin

    private float timer;
    private bool enemySpawned = false;

    Transform enemiesParent;

    public static EnemyBossManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        enemiesParent = GameObject.Find("Enemies").transform;
        timer = spawnDelay;
    }

    private void Update()
    {
        if (enemySpawned) return;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnEnemy();
            enemySpawned = true;
        }
    }

    Vector2 RandomPosition()
    {
        return new Vector2(Random.Range(-20, 20), Random.Range(-10, 10));
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, RandomPosition(), Quaternion.identity);
        enemy.transform.SetParent(enemiesParent);
    }

    public void DestroyAllEnemies()
    {
        foreach (Transform e in enemiesParent)
        {
            Destroy(e.gameObject);
        }
    }
}
