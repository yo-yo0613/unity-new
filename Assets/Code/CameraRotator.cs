using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
        public Transform centerPoint;   // 中心點
    public float radius = 10f;      // 半徑
    public float speed = 1f;        // 旋轉速度
        
    private float angle = 0f;

    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius; 

        transform.position = new Vector3(centerPoint.position.x + x, centerPoint.position.y + y, transform.position.z);
        transform.LookAt(centerPoint);  
    }
}
