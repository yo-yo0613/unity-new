using UnityEngine;
using MidiJack;

public class BambooAnimatorSpeed : MonoBehaviour
{
    public int midiCCNumber = 0;         // nanoKONTROL2 第幾個旋鈕
    public float maxSpeed = 2f;          // 最大動畫速度
    public float minSpeed = 0.1f;        // 最小動畫速度
    

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float knobValue = MidiMaster.GetKnob(midiCCNumber); // 0~1
        float speed = Mathf.Lerp(minSpeed, maxSpeed, knobValue);

        // ✅ 更新 Animator 播放速度
        animator.speed = speed;

        // ✅ Debug 訊息輸出
        Debug.Log($"[Bamboo CC#{midiCCNumber}] Knob = {knobValue:F2} → Speed = {speed:F2}");
    }
}
