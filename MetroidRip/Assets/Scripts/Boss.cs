using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private bool canDmg = false;

    private GameObject[] tenctacles;
    public GameObject[] shooters;
    public GameObject bullet;
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
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            if (canDmg) {
                GlobalVariables.bossHealth -= 1;
                StartCoroutine(resetTentacles());
            }
        }
    }

    IEnumerator resetTentacles() {
        yield return new WaitForSeconds(0.2f);
        Instantiate(bullet, shooters[0].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(bullet, shooters[2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(bullet, shooters[1].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < tenctacles.Length; i++) {
            tenctacles[i].SetActive(true);
        }
        GlobalVariables.bossTentacles = 3;
        yield return null;
    }
}
