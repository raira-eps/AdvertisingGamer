using UnityEngine;

public class BackgroundScroller2D : MonoBehaviour
{
    // 背景のスクロール速度
    [SerializeField] private float scrollSpeed = 2f;

    // 背景の高さ（ループ用）
    [SerializeField] private float backgroundHeight = 15f;


    private void Awake()
    {
        // 背景の高さを取得
        backgroundHeight = GetComponent<Renderer>().bounds.size.y;
    }
    private void Update()
    {
        // 背景を下方向に移動
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // 背景が一定位置まで移動したらリセット
        if (transform.position.y <= -backgroundHeight)
        {
            transform.position += new Vector3(0, backgroundHeight * 2, 0);
        }
    }
}