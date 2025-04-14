using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public GameObject enemyPrefab; // 敵のプレハブ
    public float spawnInterval = 2f; // 敵の生成間隔（秒）
    private float nextSpawnTime = 0f;
    
    private int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // 敵の生成
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        // ランダムなX座標で敵を生成
        float randomX = Random.Range(-8f, 8f);
        Vector3 spawnPosition = new Vector3(randomX, 6f, 0f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    public void AddScore(int value)
    {
        score += value;
        // スコアの更新処理（UIなど）をここに追加
        Debug.Log("Score: " + score);
    }
} 