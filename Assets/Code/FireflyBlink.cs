using UnityEngine;

public class FireflyBlink : MonoBehaviour
{
    private Material mat;
    private float timer = 0f;
    private bool isOn = true;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            isOn = !isOn;
            timer = 0f;
            mat.SetColor("_EmissionColor", isOn ? Color.yellow * 2f : Color.black);
        }
    }
}
