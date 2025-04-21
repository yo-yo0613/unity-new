using UnityEngine;
using MidiJack;
using System.Collections.Generic;

public class MidiDebugger : MonoBehaviour
{

    private Dictionary<int, float> lastValues = new Dictionary<int, float>();

    void Update()
    {
        for (int cc = 0; cc < 128; cc++)
        {
            float value = MidiMaster.GetKnob(cc);

            if (!lastValues.ContainsKey(cc))
                lastValues[cc] = 0f;

            // 如果這次有明顯變動，就顯示一次
            if (Mathf.Abs(value - lastValues[cc]) > 0.05f)
            {
                Debug.Log($"[CC Moved] CC#{cc} = {value}");
                lastValues[cc] = value;
            }
        }
    }
}
