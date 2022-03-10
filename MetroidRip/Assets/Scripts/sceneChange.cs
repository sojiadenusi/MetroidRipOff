using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    public void startGame(){
        SceneManager.LoadScene("Easy1");
    }

    public void quitGame(){
        Application.Quit();
    }
}
