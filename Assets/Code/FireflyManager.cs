using UnityEngine;
using MidiJack;
using System.Collections.Generic;

public class FireflyMIDIManager : MonoBehaviour
{
    public GameObject fireflyPrefab;
    public int maxFireflies = 100;
    public int midiCCNumber = 0; // nanoKONTROL2 第幾個滑桿（0~7）

    private List<GameObject> fireflies = new List<GameObject>();

    void Update()
    {
        // 讀取滑桿的值（範圍 0~1）
        float midiValue = MidiMaster.GetKnob(midiCCNumber);
        int targetCount = Mathf.RoundToInt(midiValue * maxFireflies);

        AdjustFireflyCount(targetCount);
    }

    void AdjustFireflyCount(int target)
    {
        while (fireflies.Count < target)
        {
            SpawnFirefly();
        }

        while (fireflies.Count > target)
        {
            RemoveFirefly();
        }
    }

    void SpawnFirefly()
    {
        Vector3 screenPos = new Vector3(
            Random.Range(0f, Screen.width),
            Random.Range(0f, Screen.height),
            10f // 距離攝影機一定深度（調整畫面可見範圍）
        );

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        GameObject f = Instantiate(fireflyPrefab, worldPos, Quaternion.identity);
        fireflies.Add(f);
    }

    void RemoveFirefly()
    {
        GameObject f = fireflies[fireflies.Count - 1];
        fireflies.RemoveAt(fireflies.Count - 1);
        Destroy(f);
    }
}
