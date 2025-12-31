using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rumus : MonoBehaviour
{
    public void Back(){
        SceneManager.LoadScene("MainMenu");
    }
    public void BackToCamera()
    {
        SceneManager.LoadScene("Start");
    }
}
