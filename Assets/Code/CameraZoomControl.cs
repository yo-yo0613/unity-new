using UnityEngine;
using MidiJack;

public class CameraZoomControl : MonoBehaviour
{
    public Camera mainCamera; // 用来控制的主相机
    public int zoomControlCC = 18; // MIDI 控制号，对应 nanoKontrol2 的旋钮

    public float zoomSpeed = 10f;  // 缩放速度
    public float minZoom = 5f;    // 最小缩放（对于正交相机，这是最接近的缩放）
    public float maxZoom = 20f;   // 最大缩放（对于正交相机，这是最远的缩放）

    private float targetZoom = 10f; // 相机的目标缩放值

    void Start()
    {
        // 如果没有设置主相机，则使用默认的主相机
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // 默认使用主相机
            Debug.LogWarning("Main Camera 已设置为 Camera.main");
        }
    }

    void Update()
    {
        // 获取来自 MIDI 设备（nanoKontrol2）的缩放旋钮的值
        float zoomValue = MidiMaster.GetKnob(zoomControlCC); // 获取旋钮值

        // 调试输出，检查是否正确接收到缩放值
        Debug.Log("Zoom Control Value: " + zoomValue);

        // 基于 MIDI 旋钮的输入，计算目标缩放值（在 minZoom 和 maxZoom 之间进行插值）
        targetZoom = Mathf.Lerp(minZoom, maxZoom, zoomValue); // 在最小和最大缩放值之间进行插值

        // 将相机的正交尺寸平滑过渡到目标缩放值
        if (mainCamera.orthographic) // 确保是正交相机
        {
            // 平滑过渡到目标缩放值
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
        }

        // 可选：输出当前相机的正交大小（用于调试）
        Debug.Log("Camera Orthographic Size: " + mainCamera.orthographicSize);
    }
}
