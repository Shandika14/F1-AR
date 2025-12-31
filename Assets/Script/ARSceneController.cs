using UnityEngine;

public class ARSceneController : MonoBehaviour
{
    void Start()
    {
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.GetComponent<AudioSource>().Stop();
        }
    }
}
