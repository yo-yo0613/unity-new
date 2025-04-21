using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform cameraTransform;      // 拖入主攝影機
    public float parallaxFactor = 0.1f;    // 越小越遠，越慢動

    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        // 記住原本位置，作為視差偏移的起點
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 用攝影機位置產生視差效果
        Vector3 delta = cameraTransform.position - Vector3.zero; // 以中心點(0,0)為基準
        transform.position = initialPosition + delta * parallaxFactor;
    }
}
