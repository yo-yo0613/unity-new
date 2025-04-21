using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using MidiJack;

public class SceneSwitcher : MonoBehaviour
{
    public int midiNote = 42; // 按鈕的 MIDI Note（根據 nanoPAD2 設定調整）
    public string nextSceneName; // 下一個場景名稱
    public bool waitForVideoEnd = false;

    private VideoPlayer videoPlayer;
    private bool videoFinished = false;

    void Start()
    {
        if (waitForVideoEnd)
        {
            videoPlayer = FindObjectOfType<VideoPlayer>();
            if (videoPlayer != null)
            {
                videoPlayer.loopPointReached += OnVideoFinished;
            }
        }
    }

    void Update()
    {
        if (MidiMaster.GetKeyDown(midiNote))
        {
            if (waitForVideoEnd)
            {
                // 等影片播完後才允許切換
                if (videoFinished)
                    LoadNextScene();
            }
            else
            {
                LoadNextScene();
            }
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        videoFinished = true;
        Debug.Log("影片播放完成！");
    }

    void LoadNextScene()
    {
        Debug.Log("切換到場景: " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}
