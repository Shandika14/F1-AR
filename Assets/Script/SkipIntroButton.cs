using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SkipIntroButton : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private string targetScene = "MainMenu";

    private bool isLoading = false;

    public void SkipVideo()
    {
        if (isLoading) return;
        isLoading = true;

        if (videoPlayer != null)
            videoPlayer.Stop();

        SceneManager.LoadScene(targetScene);
    }
}
