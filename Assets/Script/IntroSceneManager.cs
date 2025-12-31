using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroSceneManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.Play();
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
