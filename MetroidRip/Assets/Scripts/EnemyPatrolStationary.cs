using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrolStationary : MonoBehaviour
{
    public AudioClip deathSound;
    AudioSource _audioSource;
    

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }
    //public string level;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            _audioSource.PlayOneShot(deathSound);
            Destroy(this.gameObject);
        }else if (other.gameObject.CompareTag("Player")){
            int num = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(num);
        }
    }
}
