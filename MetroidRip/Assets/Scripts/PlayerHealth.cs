using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private bool canDmg = true;

    private void Update() {
        if (GlobalVariables.health <= 0) {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Game Over");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Enemy") || other.collider.CompareTag("EnemyShooter") || other.collider.CompareTag("MonsterBullet")) {
            if (canDmg) {
                GlobalVariables.health -= 1;
                canDmg = false;
                StartCoroutine(dmgCD());
            }
        }
        else if (other.gameObject.CompareTag("BossLaser")) {
            if (canDmg) {
                GlobalVariables.health -= 1;
                canDmg = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(-2000, GetComponent<Rigidbody2D>().velocity.y);
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
