using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private bool canDmg = false;

    private GameObject[] tenctacles;
    void Start()
    {
        tenctacles = GameObject.FindGameObjectsWithTag("Tentacle");
    }

    
    void Update()
    {
        if (GlobalVariables.bossTentacles == 0) {
            canDmg = true;
        }

        if (GlobalVariables.bossHealth == 0) {
            SceneManager.LoadScene("End");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            if (canDmg) {
                GlobalVariables.bossHealth -= 1;
                resetTentacles();
            }
        }
    }

    void resetTentacles() {
        for (int i = 0; i < tenctacles.Length; i++) {
            tenctacles[i].SetActive(true);
        }
        GlobalVariables.bossTentacles = 3;
    }
}
