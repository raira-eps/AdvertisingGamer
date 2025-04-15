using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f; // 敵の移動速度
    public float health = 3f; // 敵の体力
    public int scoreValue = 100; // 倒した時のスコア

    void Start()
    {
        // コライダーをトリガーに設定
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
        
        // タグを設定
        gameObject.tag = "Enemy";
        
        // レイヤーを設定
        gameObject.layer = LayerMask.NameToLayer("Enemy");
    }

    void Update()
    {
        // 下方向に移動
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        // 画面外に出たら破棄
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            // スコアを加算
            GameManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
} 