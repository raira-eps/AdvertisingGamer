using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレハブ
    public float bulletSpeed = 10f; // 弾の速度
    public float fireRate = 0.5f; // 発射間隔（秒）
    private float nextFireTime = 0f; // 次に発射できる時間

    void Update()
    {
        // マウスの右ボタンが押された時、かつ発射間隔を過ぎている場合
        if (Input.GetMouseButton(1) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // 弾を生成
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        
        // 弾に速度を与える
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.up * bulletSpeed;
        }
    }
} 