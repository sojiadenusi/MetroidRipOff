using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrolStationary : MonoBehaviour
{
    //public string level;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            Destroy(this.gameObject);
        }else if (other.gameObject.CompareTag("Player")){
            int num = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(num);
        }
    }
}
