using UnityEngine;
using MidiJack;

[RequireComponent(typeof(ParticleSystem))]
public class FogAlphaController : MonoBehaviour
{
    public int midiCCNumber = 0;       // nanoKONTROL2 第幾個旋鈕
    public float minAlpha = 0f;        // 最淡（完全透明）
    public float maxAlpha = 1f;        // 最濃（不透明）

    private ParticleSystem fogSystem;
    private ParticleSystem.MainModule mainModule;

    void Start()
    {
        fogSystem = GetComponent<ParticleSystem>();
        mainModule = fogSystem.main;
    }

    void Update()
    {
        float knobValue = MidiMaster.GetKnob(midiCCNumber); // 範圍 0~1
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, knobValue);

        Color currentColor = mainModule.startColor.color;
        currentColor.a = alpha;

        mainModule.startColor = currentColor;

        // Debug log
        //Debug.Log($"[Fog CC#{midiCCNumber}] knob: {knobValue:F2} → alpha: {alpha:F2}");
    }
}
