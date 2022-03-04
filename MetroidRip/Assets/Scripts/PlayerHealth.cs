using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    private bool canDmg = true;

    private void Update() {
        if (health == 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Enemy") || other.collider.CompareTag("EnemyShooter") || other.collider.CompareTag("MonsterBullet")) {
            if (canDmg) {
                health -= 1;
                canDmg = false;
                StartCoroutine(dmgCD());
            }
        }
    }

    IEnumerator dmgCD() {
        yield return new WaitForSeconds(1);
        canDmg = true;
        yield return null;
    }
}
