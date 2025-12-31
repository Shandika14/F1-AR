using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    void Start()
    {
        if (MusicManager.Instance != null)
        {
            var audio = MusicManager.Instance.GetComponent<AudioSource>();
            if (!audio.isPlaying)
                audio.Play();
        }
    }
}
