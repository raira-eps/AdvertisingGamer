using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour
{
    public float lifetime = 2f; // 弾の生存時間（秒）
    public float damage = 1f; // 弾のダメージ量

    void Start()
    {
        // コライダーをトリガーに設定
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
        
        // レイヤーを設定
        gameObject.layer = LayerMask.NameToLayer("Bullet");
        
        // 一定時間後に弾を破棄
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 敵に当たった場合
        if (other.CompareTag("Enemy"))
        {
            // 敵のダメージ処理を呼び出す
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            
            // 弾を破棄
            Destroy(gameObject);
        }
    }
} 