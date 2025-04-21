using UnityEngine;

public class FireflyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float borderPadding = 100f; // 超出畫面多少才反彈

    private Vector3 direction;

    void Start()
    {
        PickRandomDirection(); // 一開始設定方向
    }

    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // 如果超出邊界 → 反彈
        if (screenPos.x < -borderPadding || screenPos.x > Screen.width + borderPadding)
        {
            direction.x *= -1;
        }

        if (screenPos.y < -borderPadding || screenPos.y > Screen.height + borderPadding)
        {
            direction.y *= -1;
        }
    }

    void PickRandomDirection()
    {
        direction = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0f
        ).normalized;
    }
}
