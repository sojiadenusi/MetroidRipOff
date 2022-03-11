using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrolStationary : MonoBehaviour
{
    public AudioClip deathSound;
    public AudioSource _audioSource;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            animator.SetTrigger("die");
            StartCoroutine(kill());
        } else if (other.gameObject.CompareTag("Player")) {
            int num = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(num);
        }
    }

    IEnumerator kill() {
        _audioSource.PlayOneShot(deathSound);
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);
        yield return null;
    }
}
