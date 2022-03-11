using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    public void startGame(){
        GlobalVariables.ammo = 50;
        GlobalVariables.health = 10;
        SceneManager.LoadScene("Easy1");
    }

    public void quitGame(){
        Application.Quit();
    }

    public void restart(){
        GlobalVariables.ammo = 50;
        GlobalVariables.health = 10;
        SceneManager.LoadScene("title");
    }

    public void backButton(){
        GlobalVariables.ammo = 50;
        GlobalVariables.health = 10;
        SceneManager.LoadScene("title");
    }

    public void instructions(){
        GlobalVariables.ammo = 50;
        GlobalVariables.health = 10;
        SceneManager.LoadScene("Instructions");
    }

}
