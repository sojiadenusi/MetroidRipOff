using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    
    void Start()
    {
        transform.Rotate(new Vector3(0, 0, -43.901f));
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(-30, 0);

        StartCoroutine(despawn());
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(this.gameObject);
        }
    }
    IEnumerator despawn() {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        yield return null;
    }
}
