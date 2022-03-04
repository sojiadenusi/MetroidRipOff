using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolStationary : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            Destroy(this.gameObject);
        }
    }
}
