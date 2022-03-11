using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneToLoad;
private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
        GlobalVariables.ammo = 50;
        SceneManager.LoadScene(sceneToLoad);
    }
}
}
