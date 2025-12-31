using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Exit(){
        Application.Quit();
        Debug.Log("Aplikasi Telah Ditutup");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void PlayApps()
    {
        SceneManager.LoadScene("Start");
    }
}
